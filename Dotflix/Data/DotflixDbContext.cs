using Dotflix.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotflix.Data
{
    public class DotflixDbContext : DbContext
    {
        public DotflixDbContext(DbContextOptions<DotflixDbContext> options) : base (options)
        {}

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Language> Language { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DotflixDbContext).Assembly);
        }
    }
}
