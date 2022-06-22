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
        private readonly IWebHostEnvironment _env;

        public MovieService(IMovieRepository movieRepository, IWebHostEnvironment env)
        {
            _movieRepository = movieRepository;
            _env = env;
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
            movieDto.ImageUrl = await UploadImage(movieDto.ImageUrl, movieDto.Image, movieDto.Title);

            var movie = Mapping.MappingInputMovie(movieDto);

            return await _movieRepository.AddAsync(movie);
        }

        public async Task<bool> UpdateAsync(MoviePutInputDto movie)
        {

            await _movieRepository.UpdateAsync(movie);

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            return await _movieRepository.DeleteId(id);
        }

        private async Task<string> UploadImage(string imageUrl, IFormFile image, string title)
        {
            if (image != null)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\Uploads\\"))
                    Directory.CreateDirectory(_env.WebRootPath + "\\Uploads\\");

                imageUrl = Path.Combine("Uploads", $"{title}-{image.FileName}");

                using FileStream fileStream = File.Create(_env.WebRootPath +@"\"+ imageUrl);

                await image.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return imageUrl;
        }
            
    }
}
