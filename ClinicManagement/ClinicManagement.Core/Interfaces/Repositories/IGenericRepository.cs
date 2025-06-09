using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IGenericRepository<T> where T : class
  {
    // Get methods
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);

    // Add methods
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    // Update methods
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);

    // Delete methods
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    // Count methods
    Task<int> CountAsync(Expression<Func<T, bool>> expression = null);

    // Exists methods
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
  }
}
