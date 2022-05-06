using Dotflix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotflix.Data.Map
{
    public class MovieLanguageMap : IEntityTypeConfiguration<MovieLanguage>
    {
        public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.LanguageId});

            builder.Property(x => x.MovieId).HasColumnName("Movie_Id");

            builder.Property(x => x.LanguageId).HasColumnName("Language_Id");
        }
    }
}
