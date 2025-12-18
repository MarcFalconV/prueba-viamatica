using cineBackend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PeliculaCRUDController : ControllerBase
{
  private readonly IPeliculaCRUD _peliculaCRUD;

  public PeliculaCRUDController(IPeliculaCRUD peliculaCRUD)
  {
    _peliculaCRUD = peliculaCRUD;
  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<PeliculaDto>>> GetAll()
  {
    var peliculas = await _peliculaCRUD.ListarTodas();
    return Ok(peliculas);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<PeliculaDto>> GetPorId(int id)
  {
    var pelicula = await _peliculaCRUD.ObtenerPorId(id);
    if (pelicula == null) return NotFound();
    return Ok(pelicula);
  }

  [HttpPost]
  public async Task<ActionResult<PeliculaDto>> Crear(PeliculaCreacionDto dto)
  {
    await _peliculaCRUD.Crear(dto);
    return StatusCode(201); ;
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Actualizar(int id, PeliculaCreacionDto dto)
  {
    var actualizado = await _peliculaCRUD.Actualizar(id, dto);
    if (!actualizado) return NotFound();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Eliminar(int id)
  {
    var eliminado = await _peliculaCRUD.Eliminar(id);
    if (!eliminado) return NotFound();
    return NoContent();
  }
}