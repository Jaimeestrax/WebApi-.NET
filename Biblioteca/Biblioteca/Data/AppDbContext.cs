using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.NombreAutor).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Libro>(l =>
            {
                l.HasKey(l => l.Id);
                l.Property(l => l.Anio);
                l.Property(l => l.Autor);
                l.Property(l => l.TituloLibro);
                l.Property(l => l.GeneroLibro);
                l.Property(l => l.AutorId);

            });
        }


    }
}
