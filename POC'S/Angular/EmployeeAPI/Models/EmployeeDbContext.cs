using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any entity-specific configurations here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
