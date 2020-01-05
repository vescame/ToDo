using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await this.worker.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await this.worker.UserRepository.GetByIdAsync(userId);

            if (user == null) throw new Exception();

            return user;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                await this.worker.UserRepository.AddAsync(user);
                await this.worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            try
            {
                this.worker.UserRepository.Update(updatedUser);

                await this.worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return updatedUser;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var user = await this.worker.UserRepository.GetByIdAsync(userId);
            
            if (user == null) throw new Exception();

            try
            {
                this.worker.UserRepository.Remove(user);                
                await this.worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }
    }
}