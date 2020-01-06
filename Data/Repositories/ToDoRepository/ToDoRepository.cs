using ToDo.Models;

namespace ToDo.Data.Repositories.ToDoRepository
{
    public class ToDoRepository : Repository<Todo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context) { }
        public ToDoContext GetContext
        {
            get { return this.Context as ToDoContext; }
        }
    }
}