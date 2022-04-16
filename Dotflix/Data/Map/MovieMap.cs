using Dotflix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotflix.Data.Map
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);
            builder.Property(x => x.MovieId).UseIdentityColumn(100, 1);

            builder.Property(x => x.Image)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sinopse)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.ReleaseData)
                .HasColumnName("Release_data")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.AgeGroup)
                .HasColumnName("Age_group")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Relevance)
                .HasColumnType("tinyint")
                .HasDefaultValue(0);

            builder.Property(x => x.RunTime)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
