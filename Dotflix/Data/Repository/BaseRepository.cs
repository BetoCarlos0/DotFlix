using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Repository
{
    public abstract class BaseRepository<T, TContext> : IBaseRepository<T> where T : class where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getEntity = await _dbContext.Set<T>().FindAsync(id);

            if (getEntity == null)
                throw new DbUpdateException("Id não encontrado");

            return getEntity;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            //var getGenre = await _dbContext.Set<T>().FindAsync(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;

            //if (getGenre != null)
            //    getGenre.Name = genre.Name;
            //else
            //    throw new DbUpdateException("Id não existe");

            await _dbContext.SaveChangesAsync();

            return true;
            //throw new System.NotImplementedException();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var getEntity = await _dbContext.Set<T>()
                .FindAsync(id);

            if (getEntity == null)
                throw new DbUpdateException("Id não existe");

            _dbContext.Set<T>().Remove(getEntity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
