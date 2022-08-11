using api_peliculas.Entidades;
using api_peliculas.Entitys;
using Microsoft.EntityFrameworkCore;

namespace api_peliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options
                )
        {
        }

        public DbSet<Producto> T_Genero { get; set; }
        public DbSet<Usuario> T_Usuario { get; set; }

    }
}
