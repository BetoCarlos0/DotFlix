using ApiDotflix.Entities;
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
        public DbSet<Genre> Genre { get; set; }
        public DbSet<AboutGenre> AboutGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DotflixDbContext).Assembly);
        }
    }
}
