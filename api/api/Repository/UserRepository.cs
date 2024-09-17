﻿using api.Data;
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

        public async Task<UserDto> Register(UserCreateDto userCreateDto)
        {
            // Check if user with the same email already exists
            if (await _context.Users.AnyAsync(u => u.Email == userCreateDto.Email))
            {
                throw new Exception("User with the same email already exists.");
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            // Call the stored procedure to register the user
            await _context.Database.ExecuteSqlRawAsync("EXEC RegisterUser @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                parameters: new object[] {
            userCreateDto.UserName,
            hashedPassword,
            userCreateDto.Email,
            userCreateDto.PhoneNumber,
            userCreateDto.RoleID,  
            userCreateDto.Location,
            userCreateDto.Latitude,
            userCreateDto.Longitude,
            DateTime.Now
                });

            // Fetch the newly created user from the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userCreateDto.Email);

            if (user == null)
            {
                throw new Exception("User registration failed.");
            }

            // Map the user entity to UserDto and return it
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
            return await GenerateJwtToken(user);
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            // Fetch the role name from the database using RoleID
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleID);
            if (role == null)
            {
                throw new Exception("Role not found.");
            }

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.Role, role.Name),  // Fetch the role name using RoleID
        new Claim("Latitude", user.Latitude?.ToString() ?? string.Empty),
        new Claim("Longitude", user.Longitude?.ToString() ?? string.Empty)
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
