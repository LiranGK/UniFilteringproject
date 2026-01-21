using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;

namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Malshab> Malshabs { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<UniFilteringproject.Models.MalAbi> MalAbi { get; set; } = default!;
        public DbSet<UniFilteringproject.Models.AssAbi> AssAbi { get; set; } = default!;
        public DbSet<UniFilteringproject.Models.MalAss> MalAss { get; set; } = default!;
        public DbSet<MalBlock> MalBlocks { get; set; }
    }
}
