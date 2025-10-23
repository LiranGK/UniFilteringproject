using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;
namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Uni> Unis { get; set; }
        public DbSet<Malshab> Malshabs { get; set; }
        public DbSet<haiil> Haiils { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
