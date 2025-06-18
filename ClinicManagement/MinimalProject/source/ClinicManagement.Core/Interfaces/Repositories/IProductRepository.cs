using System;
using System.Collections.Generic;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    IEnumerable<Product> GetProductsByCategory(int categoryId);
    IEnumerable<Product> GetProductsByType(int productTypeId);
    IEnumerable<Product> SearchProducts(string searchTerm);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
  }
}
