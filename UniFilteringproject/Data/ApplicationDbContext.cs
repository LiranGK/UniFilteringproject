using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;

namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Uni> TheUni { get; set; }
        public DbSet<Malshab> TheMalshabs { get; set; }
        public DbSet<Corp> TheCorps { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
