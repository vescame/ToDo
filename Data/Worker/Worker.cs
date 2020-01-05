using System.Threading.Tasks;
using ToDo.Data.Repositories.UserRepository;

namespace ToDo.Data.Worker
{
    public class Worker : IWorker
    {
        private readonly ToDoContext toDoContext;
        
        public Worker(ToDoContext context)
        {
            this.toDoContext = context;
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository => userRepository = userRepository ?? new UserRepository(toDoContext);

        public async Task<int> CommitAsync()
        {
            return await this.toDoContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.toDoContext.Dispose();
        }
    }
}