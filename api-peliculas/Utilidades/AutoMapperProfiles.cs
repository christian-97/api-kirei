using api_peliculas.Dtos;
using api_peliculas.Entitys;
using AutoMapper;

namespace api_peliculas.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, GeneroDto>().ReverseMap();
            CreateMap<GeneroInsertarDto, Producto>();
        }
    }
}
