using Microsoft.EntityFrameworkCore;

namespace lab.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Banha123;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Dependent> Dependent { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Works_for> Works_For { get; set; }
    }
}
