using api_peliculas.Validaciones;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Entitys
{
    public class Genero
    {
        [Key]
        public int codigo { get; set; }
        [Required(
            ErrorMessage = "Se tiene que ingresar el nombre")
            ]
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
