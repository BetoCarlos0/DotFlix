using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class BaseMap<T> : IEntityTypeConfiguration<T>, IBaseMap<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn(100, 1);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
