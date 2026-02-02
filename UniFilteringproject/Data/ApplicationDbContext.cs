using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Models;

namespace UniFilteringproject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Malshab> Malshabs { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<MalAbi> MalAbi { get; set; }
        public DbSet<AssAbi> AssAbi { get; set; }
        public DbSet<MalAss> MalAss { get; set; }
        public DbSet<MalBlock> MalBlocks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}