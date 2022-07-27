using api_peliculas.Dtos;
using api_peliculas.Entitys;
using AutoMapper;

namespace api_peliculas.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<GeneroInsertarDto, Genero>();
        }
    }
}
