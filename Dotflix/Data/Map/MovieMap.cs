using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);
            builder.Property(x => x.MovieId)
                .UseIdentityColumn(100, 1);

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
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.AgeGroupId)
                .HasColumnName("Age_group_Id")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.Relevance)
                .HasColumnType("tinyint")
                .HasDefaultValue(0);

            builder.Property(x => x.RunTime)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Register)
                .HasColumnType("varchar")
                .HasMaxLength(20);
        }
    }
}
