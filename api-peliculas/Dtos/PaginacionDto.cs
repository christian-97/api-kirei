namespace api_peliculas.Dtos
{
    public class PaginacionDto
    {
        public int pagina { get; set; } = 1;
        private int registroxpagina = 10;
        private readonly int cantidadmaximaporpagina = 50;

        public int Registroxpagina
        {
            get
                { return registroxpagina; }
            set
            {
            registroxpagina=(value>cantidadmaximaporpagina)
            ? cantidadmaximaporpagina:value;
            }

        }
        

    }
}
