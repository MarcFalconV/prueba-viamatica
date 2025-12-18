using cineBackend.Repository;
using Microsoft.EntityFrameworkCore;


public interface IGenericRepository<T> where T : class
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<T> GetByIdAsync(int id);
  Task<T> AddAsync(T entity);
  Task<bool> UpdateAsync(T entity);
  Task<bool> DeleteAsync(int id);
}

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  protected readonly CineDemoContext _context;
  protected readonly DbSet<T> _dbSet;

  public GenericRepository(CineDemoContext context)
  {
    _context = context;
    _dbSet = context.Set<T>();
  }

  public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

  public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

  public async Task<T> AddAsync(T entity)
  {
    await _dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<bool> UpdateAsync(T entity)
  {
    _dbSet.Update(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> DeleteAsync(int id)
  {
    var entity = await _dbSet.FindAsync(id);
    if (entity == null) return false;

    if (entity is Pelicula p)
    {
      p.Activo = false;
      _context.Entry(p).State = EntityState.Modified;
    }
    else
    {
      _dbSet.Remove(entity);
    }

    return await _context.SaveChangesAsync() > 0;
  }
}