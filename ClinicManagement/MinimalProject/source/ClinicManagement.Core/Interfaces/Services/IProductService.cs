using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IProductService
  {
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(int productTypeId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    Task<IEnumerable<Product>> GetFeaturedProductsAsync();
    Task<Product> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<bool> ProductExistsAsync(int id);
    Task<int> UpdateStockAsync(int productId, int quantity);
  }
}
