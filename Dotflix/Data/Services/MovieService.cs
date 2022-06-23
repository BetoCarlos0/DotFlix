using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly FileService _file;

        public MovieService(IMovieRepository movieRepository, FileService file)
        {
            _movieRepository = movieRepository;
            _file = file;
        }

        public async Task<IEnumerable<MovieOutputDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            return Mapping.MappingMovieOutput(movies);
        }

        public async Task<MovieOutputById> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDto = new MovieOutputById
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Sinopse = movie.Sinopse,
                Image = movie.ImageUrl,
                AgeGroup = Mapping.GetAgeGroup(movie.AgeGroupId),
                Relevance = movie.Relevance,
                ReleaseData = movie.ReleaseData,
                RunTime = movie.RunTime,
                About = Mapping.MappingOutputAbout(movie.About)
            };
            return movieDto;
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _movieRepository.GetByNameAsync(name);
        }

        public async Task<bool> AddAsync(MoviePostInputDto movieDto)
        {
            movieDto.ImageUrl = await _file.UploadImage(
                0,
                movieDto.Title,
                movieDto.Image
            );

            var movie = Mapping.MappingInputMovie(movieDto);

            return await _movieRepository.AddAsync(movie);
        }

        public async Task<bool> UpdateAsync(MoviePutInputDto movie)
        {
            movie.ImageUrl = await _file.UploadImage(
                movie.MovieId,
                movie.Title,
                movie.Image
            );

            await _movieRepository.UpdateAsync(movie);

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            await _file.DeleteFile(id);
            return await _movieRepository.DeleteId(id);
        }
    }
}
