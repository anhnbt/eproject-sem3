using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
      return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
      return await _dbSet.SingleOrDefaultAsync(expression);
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
      await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
      _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
      _dbSet.UpdateRange(entities);
    }

    public void Remove(T entity)
    {
      _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
      _dbSet.RemoveRange(entities);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
    {
      if (expression == null)
        return await _dbSet.CountAsync();

      return await _dbSet.CountAsync(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
    {
      return await _dbSet.AnyAsync(expression);
    }
  }
}
