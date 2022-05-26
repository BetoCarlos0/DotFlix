using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiDotflix
{
    public static class Mapping
    {
        public static Movie MappingInputMovie(MoviePostInputDto movieDto)
        {
            var movie = new Movie();

            movie.Title = movieDto.Title;
            movie.Sinopse = movieDto.Sinopse;
            movie.RunTime = movieDto.RunTime;
            movie.Image = movieDto.Image;
            movie.AgeGroupId = movieDto.AgeGroupId;
            movie.Relevance = movieDto.Relevance;
            movie.ReleaseData = movieDto.ReleaseData;
            movie.Register = DateTime.Now.ToString("dd/MM/yyyy");

            movie.About = MappingInputAbout(movieDto.About);

            return movie;
        }

        public static IEnumerable<T> MappingListEntity<T>(IEnumerable<BaseEntityDto> convertEntity) where T : BaseEntity, new()
        {
            var entity = new List<T>();

            if (convertEntity != null)
            {
                foreach (var convert in convertEntity)
                    entity.Add(new T() { Id = convert.Id });
            }

            return entity;
        }

        public static AboutOutputDto MappingOutputAbout(About about)
        {
            var aboutDto = new AboutOutputDto
            {
                AboutId = about.AboutId,
                MovieId = about.MovieId,
                Director = about.Director,
                Casts = MappingAbout(about.AboutCasts.Select(x => x.Cast)),
                Genres = MappingAbout(about.AboutGenres.Select(x => x.Genre)),
                Keywords = MappingAbout(about.AboutKeywords.Select(x => x.Keyword)),
                Languages = MappingAbout(about.AboutLanguages.Select(x => x.Language)),
                RoadMaps = MappingAbout(about.AboutRoadMaps.Select(x => x.RoadMap))
            };

            return aboutDto;
        }

        public static List<MovieOutputDto> MappingMovieOutput(IEnumerable<Movie> movies)
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
        public static AgeGroup GetAgeGroup(string id)
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

        public static IEnumerable<T> MappingAbout<T>(IEnumerable<T> entity) where T : BaseEntity, new()
        {
            var newEntity = new List<T>();
            if (entity != null)
            {
                foreach (var entities in entity)
                    newEntity.Add(new T() { Id = entities.Id, Name = entities.Name });
            }
            return newEntity;
        }
        public static About MappingInputAbout(AboutInputDto aboutDto)
        {
            var about = new About
            {
                AboutId = aboutDto.AboutId,
                MovieId = aboutDto.MovieId,
                DirectorId = aboutDto.DirectorId,
            };

            var aboutCast = new List<AboutCast>();
            foreach (var entity in aboutDto.Casts)
                aboutCast.Add(new AboutCast() { CastId = entity.Id });

            var aboutGenre = new List<AboutGenre>();
            foreach (var entity in aboutDto.Genres)
                aboutGenre.Add(new AboutGenre() { GenreId = entity.Id });

            var aboutKeyword = new List<AboutKeyword>();
            if (aboutDto.Keywords != null)
            {
                foreach (var entity in aboutDto.Keywords)
                {
                    aboutKeyword.Add(new AboutKeyword() { KeywordId = entity.Id });
                }
            }

            var aboutLanguage = new List<AboutLanguage>();
            foreach (var entity in aboutDto.Languages)
                aboutLanguage.Add(new AboutLanguage() { LanguageId = entity.Id });

            var aboutRoad = new List<AboutRoadMap>();
            if (aboutDto.RoadMaps != null)
            {
                foreach (var entity in aboutDto.RoadMaps)
                {
                    if (entity == null) break;
                    aboutRoad.Add(new AboutRoadMap() { RoadMapId = entity.Id });
                }
            }

            about.AboutCasts = aboutCast;
            about.AboutGenres = aboutGenre;
            about.AboutKeywords = aboutKeyword;
            about.AboutLanguages = aboutLanguage;
            about.AboutRoadMaps = aboutRoad;

            return about;
        }
    }
}
