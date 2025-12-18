using cineBackend.Repository;

public interface IPeliculaLogica
{
  Task<IEnumerable<PeliculaDto>> BuscarPorNombre(string nombre);
  Task<IEnumerable<PeliculaDto>> ListarPorFecha(DateTime fecha);
  Task<string> ConsultarEstadoSala(string nombreSala);
}

public class PeliculaLogica : IPeliculaLogica
{

  private readonly IPeliculaRepository _repository;

  public PeliculaLogica(IPeliculaRepository repository)
  {
    _repository = repository;
  }

  private IEnumerable<PeliculaDto> FiltrarYMapearActivas(IEnumerable<Pelicula> peliculas)
  {
    return peliculas
        .Where(p => p.Activo == true)
        .Select(p => new PeliculaDto
        {
          IdPelicula = p.IdPelicula,
          Nombre = p.Nombre,
          Duracion = p.Duracion,
          Activo = p.Activo ?? false
        });
  }

  public async Task<IEnumerable<PeliculaDto>> BuscarPorNombre(string nombre)
  {
    if (string.IsNullOrWhiteSpace(nombre))
      throw new ArgumentException("El nombre es requerido.");

    var peliculas = await _repository.GetByNombreAsync(nombre);
    return FiltrarYMapearActivas(peliculas);
  }

  public async Task<IEnumerable<PeliculaDto>> ListarPorFecha(DateTime fecha)
  {
    if (fecha == default || fecha == DateTime.MinValue)
      throw new ArgumentException("Debe proporcionar una fecha de publicación válida y es requerida.");
    var peliculas = await _repository.GetByFechaPublicacionAsync(fecha);
    return FiltrarYMapearActivas(peliculas);
  }

  public async Task<string> ConsultarEstadoSala(string nombreSala)
  {
    if (string.IsNullOrWhiteSpace(nombreSala))
      throw new ArgumentException("El nombre de la sala es requerido.");

    int cantidadPeliculas = await _repository.ContarPeliculasPorSalaAsync(nombreSala);

    if (cantidadPeliculas < 3)
      return "Sala disponible";

    if (cantidadPeliculas >= 3 && cantidadPeliculas <= 5)
      return $"Sala con {cantidadPeliculas} películas asignadas";

    return "Sala no disponible";
  }
}