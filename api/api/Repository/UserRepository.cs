using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserRepository(DataContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        // Method to register a new user
        public async Task<UserDto> Register(UserCreateDto userCreateDto)
        {
            // Check if user with the same email already exists
            if (await _context.Users.AnyAsync(u => u.Email == userCreateDto.Email))
            {
                throw new Exception("User with the same email already exists.");
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            // Create user object
            var user = new User
            {
                UserName = userCreateDto.UserName,
                Email = userCreateDto.Email,
                Password = hashedPassword,
                PhoneNumber = userCreateDto.PhoneNumber,
                Role = userCreateDto.Role,
                Latitude = userCreateDto.Latitude,
                Longitude = userCreateDto.Longitude,
                CreatedAt = DateTime.Now
            };

            // Save the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Map to UserDto and return
            return _mapper.Map<UserDto>(user);
        }

        // Method for logging in and generating JWT
        public async Task<string> Login(LoginDTO userLoginDto)
        {
            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            // Update last login time
            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            // Generate JWT Token
            return GenerateJwtToken(user);
        }

        // Method to generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("Latitude", user.Latitude.ToString()),
            new Claim("Longitude", user.Longitude.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
