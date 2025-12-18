using cineBackend.Repository;

namespace cineBackend.Services;

public interface IPeliculaCRUD
{
  Task<IEnumerable<PeliculaDto>> ListarTodas();
  Task<PeliculaDto> ObtenerPorId(int id);
  Task<PeliculaDto> Crear(PeliculaCreacionDto dto);
  Task<bool> Actualizar(int id, PeliculaCreacionDto dto);
  Task<bool> Eliminar(int id);


}

public class PeliculaCRUD : IPeliculaCRUD
{
  private readonly IPeliculaRepository _repository;

  public PeliculaCRUD(IPeliculaRepository repository)
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

  public async Task<IEnumerable<PeliculaDto>> ListarTodas()
  {
    var peliculas = await _repository.GetAllAsync();
    return FiltrarYMapearActivas(peliculas);
  }

  public async Task<PeliculaDto> ObtenerPorId(int id)
  {
    var pelicula = await _repository.GetByIdAsync(id);

    if (pelicula == null || pelicula.Activo != true) return null;

    return new PeliculaDto
    {
      IdPelicula = pelicula.IdPelicula,
      Nombre = pelicula.Nombre,
      Duracion = pelicula.Duracion,
      Activo = pelicula.Activo ?? false
    };
  }

  public async Task<PeliculaDto> Crear(PeliculaCreacionDto dto)
  {
    var nuevaPelicula = new Pelicula
    {
      Nombre = dto.Nombre,
      Duracion = dto.Duracion,
      Activo = true
    };
    var resultado = await _repository.AddAsync(nuevaPelicula);
    return new PeliculaDto { IdPelicula = resultado.IdPelicula, Nombre = resultado.Nombre };
  }

  public async Task<bool> Actualizar(int id, PeliculaCreacionDto dto)
  {
    var peliculaExistente = await _repository.GetByIdAsync(id);
    if (peliculaExistente == null || peliculaExistente.Activo != true) return false;

    peliculaExistente.Nombre = dto.Nombre;
    peliculaExistente.Duracion = dto.Duracion;

    return await _repository.UpdateAsync(peliculaExistente);
  }

  public async Task<bool> Eliminar(int id)
  {
    return await _repository.DeleteAsync(id);
  }
}