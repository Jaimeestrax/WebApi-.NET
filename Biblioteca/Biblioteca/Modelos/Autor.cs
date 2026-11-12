namespace Biblioteca.Modelos
{
    public class Autor
    {
        public int Id { get; set; }
        public string NombreAutor { get; set; }

        public ICollection<Libro> Libros { get; set; }
        = new List<Libro>();

    }
}
