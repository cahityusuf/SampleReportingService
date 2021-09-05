using Data;
using Data.UnitOfWork;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.DataContexts
{
    public class DirectoryDbContext: UnitOfWork
    {

        public DirectoryDbContext(DbContextOptions<DirectoryDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Reports> User { get; set; }

    }
}
