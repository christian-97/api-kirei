using System;
using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Entidades
{
    public class Actor
    {
        [Key]
        public int codigo { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string biografia { get; set; }
        [Required]
        public DateTime fechanacimiento { get; set; }
        public string foto { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
