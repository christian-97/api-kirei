using api_peliculas.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Dtos
{
    public class GeneroInsertarDto
    {
        [Required]
        [StringLength(
            maximumLength: 50,
            ErrorMessage = "El nombre no debe de tener mas de 50 catacteres"
            )]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}