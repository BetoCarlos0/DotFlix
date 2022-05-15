using ApiDotflix.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotflix.Data
{
    public class DotflixDbContext : DbContext
    {
        public DotflixDbContext(DbContextOptions<DotflixDbContext> options) : base (options)
        {}

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<AboutLanguage> AboutLanguage { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<AboutKeyword> AboutKeyword { get; set; }
        public DbSet<About> About { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DotflixDbContext).Assembly);
        }
    }
}
