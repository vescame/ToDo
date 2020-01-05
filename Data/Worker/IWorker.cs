using System;
using System.Threading.Tasks;
using ToDo.Data.Repositories.UserRepository;

namespace ToDo.Data.Worker
{
    public interface IWorker : IDisposable
    {
       IUserRepository UserRepository { get; }
       Task<int> CommitAsync();
    }
}