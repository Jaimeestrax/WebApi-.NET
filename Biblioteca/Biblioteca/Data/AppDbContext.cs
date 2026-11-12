using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Nombre).IsRequired().HasMaxLength(50);
            });
        }
    }
}
