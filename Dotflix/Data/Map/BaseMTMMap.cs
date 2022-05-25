using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class BaseMTMMap<T> : IEntityTypeConfiguration<T>, IBaseMTMMap<T> where T : BaseEntityManyToMany<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => new { x.Id, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.Id).HasColumnName("Id");
        }
    }
}
