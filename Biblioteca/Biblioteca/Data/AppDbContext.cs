using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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

                // Datos iniciales de autores
                a.HasData(
                    new Autor { Id = 1, NombreAutor = "Gabriel García Márquez" },
                    new Autor { Id = 2, NombreAutor = "Julio Cortázar" },
                    new Autor { Id = 3, NombreAutor = "Mario Vargas Llosa" }
                );
            });

            modelBuilder.Entity<Libro>(l =>
            {
                l.HasKey(l => l.Id);
                l.Property(l => l.TituloLibro).IsRequired().HasMaxLength(100);
                l.Property(l => l.GeneroLibro).IsRequired().HasMaxLength(50);
                l.Property(l => l.Anio).IsRequired();
                l.HasOne(l => l.Autor).WithMany(a => a.Libros).HasForeignKey(l => l.AutorId);

                // Datos iniciales de libros
                l.HasData(
                    new Libro
                    {
                        Id = 1,
                        TituloLibro = "Cien años de soledad",
                        GeneroLibro = "Realismo mágico",
                        Anio = 1967,
                        AutorId = 1
                    },
                    new Libro
                    {
                        Id = 2,
                        TituloLibro = "Rayuela",
                        GeneroLibro = "Novela",
                        Anio = 1963,
                        AutorId = 2
                    },
                    new Libro
                    {
                        Id = 3,
                        TituloLibro = "La ciudad y los perros",
                        GeneroLibro = "Novela",
                        Anio = 1963,
                        AutorId = 3
                    }
                );
            });
        }


    }
}
