

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class PeliculaLogicaController : ControllerBase
{
  private readonly IPeliculaLogica _peliculaLogica;

  public PeliculaLogicaController(IPeliculaLogica peliculaLogica)
  {
    _peliculaLogica = peliculaLogica;
  }

  [HttpGet("buscar")]
  public async Task<ActionResult<IEnumerable<PeliculaDto>>> GetNombre([FromQuery] string nombre)
  {
    var resultados = await _peliculaLogica.BuscarPorNombre(nombre);
    return Ok(resultados);
  }

  [HttpGet("por-fecha")]
  public async Task<ActionResult<IEnumerable<PeliculaDto>>> GetFecha([FromQuery] DateTime fecha)
  {
    try
    {
      var resultados = await _peliculaLogica.ListarPorFecha(fecha);
      return Ok(resultados);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new { mensaje = ex.Message });
    }
  }

  [HttpGet("estado-sala")]
  public async Task<ActionResult<object>> GetEstadoSala([FromQuery] string nombreSala)
  {
    try
    {
      var mensaje = await _peliculaLogica.ConsultarEstadoSala(nombreSala);
      return Ok(new { mensaje_estado = mensaje });
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new { mensaje = ex.Message });
    }
  }
}
