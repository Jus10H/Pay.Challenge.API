using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaylocityChallenge.DLL.Entities;

namespace PaylocityChallenge.DLL
{
    public class PaylocityDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public PaylocityDbContext(DbContextOptions options, IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("PaylocityDB"));
        }
    }
}
