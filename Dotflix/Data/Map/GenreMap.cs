using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.GenreId);
            builder.Property(x => x.GenreId)
                .HasColumnName("Genre_Id");

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
