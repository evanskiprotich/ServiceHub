using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<UserDto> Register(UserCreateDto userCreateDto);
        Task<string> Login(LoginDTO userLoginDto);
        //Task<UserDto> Login(LoginDTO userLoginDto);
    }
}
