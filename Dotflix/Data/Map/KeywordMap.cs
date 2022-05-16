using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class KeywordMap : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Keyword_Id");

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
