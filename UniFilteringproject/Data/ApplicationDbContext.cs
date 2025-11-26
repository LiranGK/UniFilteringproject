using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;

namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Uni> Uni { get; set; }
        public DbSet<Malshab> Malshabs { get; set; }
        public DbSet<Corp> Corps { get; set; }
        public DbSet<Models.Ability> Abilities { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
