using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Data.Concrete.Configurations;
using AwesomeToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Data.Concrete
{
    public class EfContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ToDo> ToDos { get; set; }


        public EfContext(DbContextOptions<EfContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new ToDoConfiguration());
        }
    }
}
