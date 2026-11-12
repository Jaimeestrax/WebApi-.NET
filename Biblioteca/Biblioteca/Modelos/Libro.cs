namespace Biblioteca.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public string TituloLibro { get; set; }
        public string GeneroLibro { get; set; }
        public int Anio { get; set; }

        // Relación uno a muchos
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

    }
}
