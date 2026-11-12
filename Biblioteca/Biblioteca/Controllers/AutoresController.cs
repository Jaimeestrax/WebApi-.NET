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
        List<Autor> autores = await _db.Autores
            .AsNoTracking()
            .OrderBy(a => a.NombreAutor)
            .ToListAsync();

        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> obtenerPorId(int id)
    {
        Autor? autor = await _db.Autores.FindAsync(id);
        if (autor is null) return NotFound();

        return Ok(autor);
    }
}
