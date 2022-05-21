using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class AboutCastMap : IEntityTypeConfiguration<AboutCast>
    {
        public void Configure(EntityTypeBuilder<AboutCast> builder)
        {
            builder.HasKey(x => new { x.CastId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.CastId).HasColumnName("Cast_Id");
        }
    }
}
