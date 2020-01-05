using Microsoft.EntityFrameworkCore;
using ToDo.Data.Configuration;
using ToDo.Models;

namespace ToDo.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ToDoContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}