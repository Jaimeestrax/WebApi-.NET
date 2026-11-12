namespace Biblioteca.Modelos
{
    public class Autor
    {
        public int Id { get; set; }
        public string NombreAutor { get; set; }

        // relación uno a muchos
        public List<Libro> Libros { get; set; } = new List<Libro>();

    }
}
