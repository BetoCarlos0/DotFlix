using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public abstract class BaseService<T, TRepository> : IBaseService<T> where T : class where TRepository : IBaseRepository<T>
    //public abstract class BaseService<T, TContext> : IBaseService<T> where T : class where TContext : DbContext
    {
        private readonly TRepository _baseRepository;
        //private readonly TContext _context;
        //protected BaseService(TContext context)
        //{
        //    _context = context;
        //}

        public BaseService(TRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //return await _context.Set<T>().ToListAsync();
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            //var getKey = await _keywordRepository.GetByNameAsync(keyword.Name);

            //if (getKey == null)
            return await _baseRepository.AddAsync(entity);
            //else
                //throw new DbUpdateException($"{getKey.Name} já existente");
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            //var getKey = await _keywordRepository.GetByNameAsync(keyword.Name);

            //if (getKey == null)
            return await _baseRepository.UpdateAsync(entity);

            //if (getKey.KeywordId != keyword.KeywordId)
            //    throw new DbUpdateException($"{getKey.Name} já existente");

            //return true;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _baseRepository.RemoveByIdAsync(id);
        }
    }
}
