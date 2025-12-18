using Microsoft.EntityFrameworkCore;

namespace cineBackend.Repository
{

  public interface IPeliculaRepository : IGenericRepository<Pelicula>
  {
    Task<IEnumerable<Pelicula>> GetByNombreAsync(string nombre);

    Task<IEnumerable<Pelicula>> GetByFechaPublicacionAsync(DateTime fecha);
    Task<int> ContarPeliculasPorSalaAsync(string nombreSala);
  }

  public class PeliculaRepository : GenericRepository<Pelicula>, IPeliculaRepository
  {
    public PeliculaRepository(CineDemoContext context) : base(context) { }

    public async Task<IEnumerable<Pelicula>> GetByNombreAsync(string nombre)
    {
      return await _context.Peliculas
          .Where(p => p.Nombre.Contains(nombre) && p.Activo == true)
          .ToListAsync();
    }

    public async Task<IEnumerable<Pelicula>> GetByFechaPublicacionAsync(DateTime fecha)
    {
      return await _context.PeliculaSalacines
          .Where(ps => ps.FechaPublicacion.Date == fecha.Date)
          .Select(ps => ps.IdPeliculaNavigation)
          .Distinct()
          .ToListAsync();
    }

    public async Task<int> ContarPeliculasPorSalaAsync(string nombreSala)
    {
      return await _context.PeliculaSalacines
          .CountAsync(ps => ps.IdSalaCineNavigation.Nombre.Contains(nombreSala)
                            && ps.IdSalaCineNavigation.Activo == true);
    }
  }
}