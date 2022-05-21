using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
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

            return MappingMovieOutput(movies);
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _movieRepository.GetByNameAsync(name);
        }

        public async Task<bool> AddAsync(MoviePostInputDto movieDto)
        {
            var getMovie = await _movieRepository.GetByNameAsync(movieDto.Title);

            if (getMovie != null)
                throw new DbUpdateException($"{getMovie.Title} já existente");

            var movie = MappingInputMovie(movieDto);

            return await _movieRepository.AddAsync(movie);
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

        private Movie MappingInputMovie(MoviePostInputDto movieDto)
        {
            var movie = new Movie();
            var about = new About();

            movie.Title = movieDto.Title;
            movie.Sinopse = movieDto.Sinopse;
            movie.RunTime = movieDto.RunTime;
            movie.Image = movieDto.Image;
            movie.AgeGroup = movieDto.AgeGroup;
            movie.Relevance = movieDto.Relevance;
            movie.ReleaseData = movieDto.ReleaseData;
            movie.Register = DateTime.Now.ToString("dd/MM/yyyy");

            about.DirectorId = movieDto.About.DirectorId;
            about.Languages = MappingListEntity<Language>(movieDto.About.Languages);
            about.Keywords = MappingListEntity<Keyword>(movieDto.About.Keywords);
            about.Casts = MappingListEntity<Cast>(movieDto.About.Casts);
            about.Genres = MappingListEntity<Genre>(movieDto.About.Genres);
            about.RoadMaps = MappingListEntity<RoadMap>(movieDto.About.RoadMaps);

            movie.About = about;

            return movie;
        }

        private IEnumerable<T> MappingListEntity<T>(IEnumerable<BaseEntityDto> convertEntity) where T : BaseEntity, new()
        {
            var entity = new List<T>();

            if (convertEntity != null)
            {
                foreach (var convert in convertEntity)
                    entity.Add(new T() { Id = convert.Id});
            }

            return entity;
        }

        private List<MovieOutputDto> MappingMovieOutput(IEnumerable<Movie> movies)
        {
            var ListMovie = new List<MovieOutputDto>();

            foreach (var movie in movies)
            {
                ListMovie.Add(new MovieOutputDto
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    AgeGroup = movie.AgeGroup,
                    Image = movie.Image,
                    Relevance = movie.Relevance,
                    RunTime = movie.RunTime
                });
            }
            return ListMovie;
        }
    }
}
