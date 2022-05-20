using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class AboutRoadMapMap : IEntityTypeConfiguration<AboutRoadMap>
    {
        public void Configure(EntityTypeBuilder<AboutRoadMap> builder)
        {
            builder.HasKey(x => new { x.RoadMapId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.RoadMapId).HasColumnName("RoadMap_Id");
        }
    }
}
