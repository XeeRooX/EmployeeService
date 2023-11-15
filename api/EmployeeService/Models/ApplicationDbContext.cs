using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            InitializeDb.Initialize(builder);
        }
    }
}
