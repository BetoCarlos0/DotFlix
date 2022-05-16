using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(Genre genre)
        {
            var getGenre = await _genreRepository.GetByNameAsync(genre.Name);

            if (getGenre == null)
                return await _genreRepository.AddAsync(genre);
            else
                throw new DbUpdateException($"{getGenre.Name} já existente");
        }

        public async Task<bool> UpdateAsync(Genre genre)
        {
            var getGenre = await _genreRepository.GetByNameAsync(genre.Name);

            if (getGenre == null)
                return await _genreRepository.UpdateAsync(genre);

            if (getGenre.GenreId != genre.GenreId)
                throw new DbUpdateException($"{getGenre.Name} já existente");

            return true;
        }
        public async Task<bool> DeleteId(int id)
        {
            return await _genreRepository.DeleteId(id);
        }
    }
}
