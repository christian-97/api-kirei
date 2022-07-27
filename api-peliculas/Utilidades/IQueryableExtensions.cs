using api_peliculas.Dtos;
using System.Linq;

namespace api_peliculas.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(
            this IQueryable<T> queryable,PaginacionDto paginacionDto)
        {
            return queryable
                .Skip((paginacionDto.pagina-1)*paginacionDto.Registroxpagina)
                .Take(paginacionDto.Registroxpagina);
        }
    }
}
