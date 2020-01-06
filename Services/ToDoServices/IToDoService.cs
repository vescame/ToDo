using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services.ToDoServices
{
    public interface IToDoService
    {
       Task<IEnumerable<Todo>> GetAllToDos();
       Task<Todo> GetToDoById(int toDoId);
       Task<Todo> CreateToDo(Todo newToDo);
       Task<Todo> UpdateToDo(Todo updatedToDo);
       Task<Todo> DeleteToDo(int toDoId);
    }
}