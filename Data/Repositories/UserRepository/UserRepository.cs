using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context) { }
        public ToDoContext GetContext {
            get { return this.Context as ToDoContext; }
        }

        public async Task<bool> LoginAllowed(User user)
        {
            return 
                await this.GetContext
                .Users
                .SingleOrDefaultAsync(
                    u =>
                        u.Email == user.Email
                        && u.Password == user.Password) != null;
        }
    }
}