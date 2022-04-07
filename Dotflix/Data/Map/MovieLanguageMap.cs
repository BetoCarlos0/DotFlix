using Dotflix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotflix.Data.Map
{
    public class MovieLanguageMap //: IEntityTypeConfiguration<MovieLanguage>
    {

        /*public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasKey(x => x.MovieLanguageId);

            builder.Property(x => x.MovieLanguageId)
                .UseIdentityColumn(100, 1);
        }*/
    }
}
