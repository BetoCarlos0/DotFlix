using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieOutputDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            return MappingMovieOutput(movies);
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            movie.AgeGroup = GetAgeGroup(movie.AgeGroupId);

            return movie;
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _movieRepository.GetByNameAsync(name);
        }

        public async Task<bool> AddAsync(MoviePostInputDto movieDto)
        {
            var movie = MappingInputMovie(movieDto);

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

        private Movie MappingInputMovie(MoviePostInputDto movieDto)
        {
            var movie = new Movie();
            var about = new About();

            movie.Title = movieDto.Title;
            movie.Sinopse = movieDto.Sinopse;
            movie.RunTime = movieDto.RunTime;
            movie.Image = movieDto.Image;
            movie.AgeGroupId = movieDto.AgeGroupId;
            movie.Relevance = movieDto.Relevance;
            movie.ReleaseData = movieDto.ReleaseData;
            movie.Register = DateTime.Now.ToString("dd/MM/yyyy");
            /*
            about.DirectorId = movieDto.About.DirectorId;
            about.Languages = MappingListEntity<Language>(movieDto.About.Languages);
            about.Keywords = MappingListEntity<Keyword>(movieDto.About.Keywords);
            about.Casts = MappingListEntity<Cast>(movieDto.About.Casts);
            about.Genres = MappingListEntity<Genre>(movieDto.About.Genres);
            about.RoadMaps = MappingListEntity<RoadMap>(movieDto.About.RoadMaps);
            */
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
                    AgeGroup = GetAgeGroup(movie.AgeGroupId),
                    Image = movie.Image,
                    Relevance = movie.Relevance,
                    RunTime = movie.RunTime
                });
            }
            return ListMovie;
        }
        private AgeGroup GetAgeGroup(string id)
        {
            var ageGroup = new List<AgeGroup>()
            {
                new AgeGroup("L", "Livre", "Não expõe crianças a conteúdo potencialmente prejudiciais"),
                new AgeGroup("10", "Não recomendado para menores de 10 anos",
                            "Conteúdo violento ou linguagem inapropírada para crianças"),
                new AgeGroup("12", "Não recomendado para menores de 12 anos",
                            "Cenas podem conter agressão física, consumo de drogas e insinuação sexual"),
                new AgeGroup("14", "Não recomendado para menores de 14 anos",
                            "Conteúdos mais violentos e/ou de linguagem sexual mais acentuada"),
                new AgeGroup("16", "Não recomendado para menores de 16 anos",
                            "Conteúdo mais violentos, com cenas de tortura, suicídio, estupro ou nudez total"),
                new AgeGroup("18", "Não recomendado para menores de 18 anos",
                            "Conteúdos violentos e sexuais extremos. Cenas de sexo, incesto ou atos repetidos de tortura, multilação ou abuso sexual")
            };

            foreach (var age in ageGroup)
            {
                if (age.Symbol == id)
                    return age;
            }
            return null;
        }
    }
}
