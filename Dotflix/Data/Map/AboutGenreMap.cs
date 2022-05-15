using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class AboutGenreMap : IEntityTypeConfiguration<AboutGenre>
    {
        public void Configure(EntityTypeBuilder<AboutGenre> builder)
        {
            builder.HasKey(x => new { x.GenreId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.GenreId).HasColumnName("Genre_Id");
        }
    }
}
