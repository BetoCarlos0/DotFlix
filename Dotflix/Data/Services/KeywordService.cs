using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts;
using ApiDotflix.Entities.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IKeywordRepository _keywordRepository;

        public KeywordService(IKeywordRepository keywordRepository)
        {
            _keywordRepository = keywordRepository;
        }

        public async Task<IEnumerable<Keyword>> GetAllAsync()
        {
            return await _keywordRepository.GetAllAsync();
        }

        public async Task<Keyword> GetByIdAsync(int id)
        {
            return await _keywordRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(Keyword keyword)
        {
            var getKey = await _keywordRepository.GetByNameAsync(keyword.Name);

            if (getKey == null)
                return await _keywordRepository.AddAsync(keyword);
            else
                throw new DbUpdateException($"{getKey.Name} já existente");
        }

        public async Task<bool> UpdateAsync(Keyword keyword)
        {
            var getKey = await _keywordRepository.GetByNameAsync(keyword.Name);

            if (getKey == null)
                return await _keywordRepository.UpdateAsync(keyword);

            if (getKey.KeywordId != keyword.KeywordId)
                throw new DbUpdateException($"{getKey.Name} já existente");

            return true;
        }
        public async Task<bool> DeleteId(int id)
        {
            return await _keywordRepository.DeleteId(id);
        }
    }
}
