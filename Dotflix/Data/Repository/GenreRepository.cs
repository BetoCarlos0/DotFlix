using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DotflixDbContext _dbContext;

        public GenreRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _dbContext.Genre
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var getGenre = await _dbContext.Genre.FindAsync(id);

            if (getGenre == null)
                throw new DbUpdateException("Id não encontrado");

            return getGenre;
        }

        public async Task<Genre> GetByNameAsync(string name)
        {
            return await _dbContext.Genre.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<bool> AddAsync(Genre genre)
        {
            await _dbContext.Genre.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Genre genre)
        {
            var getGenre = await _dbContext.Genre.FirstOrDefaultAsync(x => x.GenreId.Equals(genre.GenreId));

            if (getGenre != null)
                getGenre.Name = genre.Name;
            else
                throw new DbUpdateException("Id não existe");

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            var getGenre = await _dbContext.Genre
                .FindAsync(id);

            if (getGenre == null)
                throw new DbUpdateException("Id não existe");

            _dbContext.Remove(getGenre);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
