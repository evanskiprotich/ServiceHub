using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserCreateDto userCreateDto)
        {
            try
            {
                var user = await _userRepository.Register(userCreateDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Login to generate JWT
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDto)
        {
            try
            {
                var token = await _userRepository.Login(loginDto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        // Get all users (Admin only)
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        // Get user by id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Get user by email
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Update user
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Role = userDto.Role;

            await _userRepository.UpdateUserAsync(user);
            return NoContent();
        }

        // Delete user
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            await _userRepository.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
