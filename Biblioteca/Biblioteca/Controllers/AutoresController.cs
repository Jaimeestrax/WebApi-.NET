using Biblioteca.Data;
using Biblioteca.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]

public class AutoresController : ControllerBase
{
    private readonly AppDbContext _db;
    public AutoresController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> obtenerTodos()
    {
        List<AutoresResumen> autores = await _db.Autores
            .AsNoTracking()
            .OrderBy(a => a.NombreAutor)
            .Select(a => new AutoresResumen(a.Id, a.NombreAutor, a.Libros.Count(), a.Libros.Select(l => l.TituloLibro).ToList()))
            .ToListAsync();

        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> obtenerPorId(int id)
    {
        AutoresResumen? autor = await _db.Autores
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new AutoresResumen(a.Id, a.NombreAutor, a.Libros.Count(), a.Libros.Select(l => l.TituloLibro).ToList()))
            .FirstOrDefaultAsync();

        if (autor is null) return NotFound();

        return Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> crear(Autor autor)
    {
        _db.Autores.Add(autor);
        await _db.SaveChangesAsync();

        AutoresResumen resumen = new AutoresResumen(
            autor.Id,
            autor.NombreAutor,
            autor.Libros.Count(),
            autor.Libros.Select(l => l.TituloLibro).ToList()
        );

        // Devuelve respuesta created, genera cabecera http para consultar el recurso
        return CreatedAtAction(nameof(obtenerPorId), new { id = autor.Id }, resumen);
        // 1. Función que permite consultar el recurso creado
        // 2. Parametros de la ruta
        // 3. Objeto que se quiere devolver en la respuesta
    }
}
