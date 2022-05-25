using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{/*
    public class BaseMTMMap<T> : IEntityTypeConfiguration<T>, IBaseMTMMap<T> where T : BaseEntityManyToMany
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => new { x.BaseId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.BaseId).HasColumnName("Id");
        }
    }*/
}
