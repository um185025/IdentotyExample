using IdentotyExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentotyExample.Data
{
    public class DataContext : IdentityDbContext <User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                    .Property(b => b.FirstName)
                    .HasDefaultValue("DefaultName");

            modelBuilder.Entity<User>()
                .Property(b => b.LastName)
                .HasDefaultValue("DefaultName");

            modelBuilder.Entity<User>()
                .HasMany(user => user.Addresses)
                .WithOne(address => address.User)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Address { get; set; }

    }
}
