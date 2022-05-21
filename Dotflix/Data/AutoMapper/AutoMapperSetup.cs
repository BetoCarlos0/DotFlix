using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Dtos;
using AutoMapper;

namespace ApiDotflix.Data.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<Movie, MovieOutputDto>();

            CreateMap<MoviePostInputDto, Movie>();
        }
    }
}
