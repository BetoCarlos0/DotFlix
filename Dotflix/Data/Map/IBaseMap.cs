using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public interface IBaseMap<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder);
    }
}
