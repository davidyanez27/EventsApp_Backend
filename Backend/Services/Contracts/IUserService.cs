using Backend.Models;

namespace Backend.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
