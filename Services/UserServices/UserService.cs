using System.Threading.Tasks;
using ToDo.Data.Worker;
using ToDo.Models;

namespace ToDo.Services.UserServices
{
    public class UserService : IUserService
    {
        private IWorker worker;
        public UserService(IWorker worker)
        {
            this.worker = worker;
        }

        public async Task<bool> Login(User user)
        {
            return await this.worker.UserRepository.LoginAllowed(user);
        }
    }
}