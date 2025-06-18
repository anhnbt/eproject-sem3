using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Core.Interfaces.Services;

namespace ClinicManagement.Core.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IProductRepository _productRepository;
    private readonly List<Category> _categories; // Temporary in-memory storage

    public CategoryService(IProductRepository productRepository)
    {
      _productRepository = productRepository;

      // In a real application, categories would be stored in a database
      // This is a temporary in-memory implementation
      _categories = new List<Category>();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
      // In a real application, this would fetch from a database
      return _categories;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
      return _categories.Find(c => c.Id == id);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
      // Set audit fields
      category.CreatedAt = DateTime.Now;
      category.UpdatedAt = DateTime.Now;

      // In a real implementation, this would save to a database
      if (_categories.Count == 0)
      {
        category.Id = 1;
      }
      else
      {
        category.Id = _categories.Max(c => c.Id) + 1;
      }

      _categories.Add(category);

      return category;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
      category.UpdatedAt = DateTime.Now;

      // In a real implementation, this would update in a database
      var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
      if (existingCategory != null)
      {
        int index = _categories.IndexOf(existingCategory);
        _categories[index] = category;
      }
    }

    public async Task DeleteCategoryAsync(int id)
    {
      // In a real implementation, this would delete from a database
      var category = _categories.FirstOrDefault(c => c.Id == id);
      if (category != null)
      {
        _categories.Remove(category);
      }
    }
  }
}
