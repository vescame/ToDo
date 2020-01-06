using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Data.Worker;
using ToDo.Models;

namespace ToDo.Services.ToDoServices
{
    class ToDoService : IToDoService
    {
        private readonly IWorker worker;
        public ToDoService(IWorker worker)
        {
            this.worker = worker;
        }

        public async Task<IEnumerable<Todo>> GetAllToDos()
        {
            return await this.worker.ToDoRepository.GetAllAsync();
        } 

        public async Task<Todo> GetToDoById(int toDoId)
        {
            var todo = await this.worker.ToDoRepository.GetByIdAsync(toDoId);

            if (todo == null)
                throw new Exception();
        
            return todo;
        }

        public async Task<Todo> CreateToDo(Todo newToDo)
        {
            try
            {
                await this.worker.ToDoRepository.AddAsync(newToDo);
                await this.worker.CommitAsync(); 
            }
            catch (Exception e)
            {
                throw e;
            }
            return newToDo;
        }

        public async Task<Todo> UpdateToDo(Todo updatedToDo)
        {
            try
            {
                this.worker.ToDoRepository.Update(updatedToDo);
                await this.worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return updatedToDo;
        }

        public async Task<Todo> DeleteToDo(int toDoId)
        {
            var todo = await this.worker.ToDoRepository.GetByIdAsync(toDoId);
            
            if (todo == null) throw new Exception();

            try
            {
                this.worker.ToDoRepository.Remove(todo);
                await this.worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return todo;
        }
    }
}