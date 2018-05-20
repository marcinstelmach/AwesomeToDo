using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Data.Abstract
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; } 
        DbSet<Card> Cards { get; set; }
        DbSet<ToDo> ToDos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
