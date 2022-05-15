using ApiDotflix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class AboutKeywordMap : IEntityTypeConfiguration<AboutKeyword>
    {
        public void Configure(EntityTypeBuilder<AboutKeyword> builder)
        {
            builder.HasKey(x => new { x.KeywordId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.KeywordId).HasColumnName("Keyword_Id");
        }
    }
}
