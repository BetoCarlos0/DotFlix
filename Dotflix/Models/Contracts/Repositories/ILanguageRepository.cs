using System.Collections.Generic;

namespace Dotflix.Models.Contracts
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetAll();
        IEnumerable<Language> GetById(int id);
        void Create(Language entity);
        void Update(Language entity);
        void DeleteId(int id);
    }
}
