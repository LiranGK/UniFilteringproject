using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;
namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<TEntity> properties here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
