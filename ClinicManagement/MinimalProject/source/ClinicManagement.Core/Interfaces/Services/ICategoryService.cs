using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface ICategoryService
  {
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
  }
}
