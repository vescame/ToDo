using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> Login(User user);
    }
}