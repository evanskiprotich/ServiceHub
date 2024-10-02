using api.Dtos.User;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO userLoginDto)
        {
            try
            {
                var token = await _userRepository.Login(userLoginDto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO userLoginDto)
        //{
        //    try
        //    {
        //        // Call the Login method in the repository to get the user details
        //        var user = await _userRepository.Login(userLoginDto);

        //        // Return the user details
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Return an Unauthorized status with the error message
        //        return Unauthorized(new { message = ex.Message });
        //    }
        //}

    }
}