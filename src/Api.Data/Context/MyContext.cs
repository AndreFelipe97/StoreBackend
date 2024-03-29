using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CostumerEntity> Costumers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<CostumerEntity>(new CustomerMap().Configure);
        }
    }
}
