using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Model;
using MongoDB.EntityFrameworkCore.Extensions;

namespace RegistrationAPI.Model
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
        {
        }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Registration>().ToCollection("registrations");
            // No explicit mapping, rely on 'id' convention or BsonId attribute
        }
    }
}
