using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Data.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> LoginAllowed(User user);
    }
}