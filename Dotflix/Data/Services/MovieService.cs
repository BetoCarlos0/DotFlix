using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieOutputDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            var movieDto = _mapper.Map<List<MovieOutputDto>>(movies);

            return movieDto;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _movieRepository.GetByNameAsync(name);
        }

        public async Task<bool> AddAsync(MovieInputDto movieDto)
        {
            var getMovie = await _movieRepository.GetByNameAsync(movieDto.Title);

            if (getMovie == null)
            {
                /*var movie = new Movie();
                var about = new About();

                var langs = new List<Language>();
                var key = new List<Keyword>();
                var cast = new List<Cast>();
                var genre = new List<Genre>();
                var road = new List<RoadMap>();

                if (movieDto.About.Keywords != null)
                {
                    foreach (var lang in movieDto.About.Keywords)
                        key.Add(new Keyword { Id = lang.Id, Name = null });
                }

                if (movieDto.About.RoadMaps != null)
                {
                    foreach (var lang in movieDto.About.RoadMaps)
                        road.Add(new RoadMap { Id = lang.Id, Name = null });
                }

                foreach (var lang in movieDto.About.Languages)
                    langs.Add(new Language { Id = lang.Id, Name = null });

                foreach (var lang in movieDto.About.Casts)
                    cast.Add(new Cast { Id = lang.Id, Name = null });

                foreach (var lang in movieDto.About.Genres)
                    genre.Add(new Genre { Id = lang.Id, Name = null });

                movie.Title = movieDto.Title;
                movie.Sinopse = movieDto.Sinopse;
                movie.RunTime = movieDto.RunTime;
                movie.Image = movieDto.Image;
                movie.AgeGroup = movieDto.AgeGroup;
                movie.Relevance = movieDto.Relevance;
                movie.ReleaseData = movieDto.ReleaseData;
                movie.Register = DateTime.Now.ToString("dd/MM/yyyy");

                about.DirectorId = movieDto.About.DirectorId;
                about.Languages = langs;
                about.Keywords = key;
                about.Casts = cast;
                about.Genres = genre;
                about.RoadMaps = road;

                movie.About = about;*/
                Movie movie = _mapper.Map<Movie>(movieDto);
                movie.Register = DateTime.Now.ToString("dd/MM/yyyy");

                return await _movieRepository.AddAsync(movie);
            }
            else
                throw new DbUpdateException($"{movieDto.Title} já existente");
        }

        public async Task<bool> UpdateAsync(Movie movie) 
        {
            var getMovie = await _movieRepository.GetByNameAsync(movie.Title);

            if (getMovie == null)
                return await _movieRepository.UpdateAsync(movie);

            if (getMovie.MovieId != movie.MovieId)
                throw new DbUpdateException($"{getMovie.Title} já existente");

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            return await _movieRepository.DeleteId(id);
        }
    }
}
