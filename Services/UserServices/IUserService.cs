using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> Login(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User updatedUser);
        Task<User> DeleteUser(int userId);
    }
}