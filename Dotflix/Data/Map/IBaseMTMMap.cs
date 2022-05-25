using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Data.Map
{
    public interface IBaseMTMMap<T> where T : BaseEntityManyToMany<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<T> builder);
    }
}
