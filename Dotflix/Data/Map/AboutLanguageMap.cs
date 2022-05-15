using ApiDotflix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public class AboutLanguageMap : IEntityTypeConfiguration<AboutLanguage>
    {
        public void Configure(EntityTypeBuilder<AboutLanguage> builder)
        {
            builder.HasKey(x => new { x.LanguageId, x.AboutId });

            builder.Property(x => x.AboutId).HasColumnName("About_Id");

            builder.Property(x => x.LanguageId).HasColumnName("Language_Id");
        }
    }
}
