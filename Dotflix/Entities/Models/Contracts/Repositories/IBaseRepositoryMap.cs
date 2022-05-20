using ApiDotflix.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotflix.Entities.Models.Contracts.Repositories
{
    public interface IBaseRepositoryMap<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder);
    }
}
