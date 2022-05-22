using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DotflixDbContext _dbContext;
        private DbSet<T> _entities;

        public BaseRepository(DotflixDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ExistEntity(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            await NameExiste(entity);

            await _entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await NameExiste(entity);

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            _entities.Remove(await ExistEntity(id));
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task NameExiste(T entity)
        {
            var getEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Name.Equals(entity.Name));

            if (getEntity != null)
                throw new DbUpdateException($"{entity.Name} já existente");
        }

        private async Task<T> ExistEntity(int id)
        {
            var getEntity = await _entities.FindAsync(id);

            if (getEntity == null)
                throw new DbUpdateException("Id não encontrado");

            return getEntity;
        }
    }
}
