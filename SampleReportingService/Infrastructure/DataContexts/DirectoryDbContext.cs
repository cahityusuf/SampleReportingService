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

        public DbSet<User> User { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<ContactType> ContactType { get; set; }


    }
}
