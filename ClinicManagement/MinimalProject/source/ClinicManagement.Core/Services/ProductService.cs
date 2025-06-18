using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Core.Interfaces.Services;

namespace ClinicManagement.Core.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      // In a real application, this would be an async call to the repository
      return _productRepository.GetAllProducts();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return _productRepository.GetProductById(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
      return _productRepository.GetProductsByCategory(categoryId);
    }

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(int productTypeId)
    {
      return _productRepository.GetProductsByType(productTypeId);
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
      return _productRepository.SearchProducts(searchTerm);
    }

    public async Task<IEnumerable<Product>> GetFeaturedProductsAsync()
    {
      // This could be customized based on business logic
      // For now, we'll return products that are featured
      return _productRepository.GetAllProducts()
          .Where(p => p.IsFeatured);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
      // Set audit fields
      product.CreatedAt = DateTime.Now;
      product.UpdatedAt = DateTime.Now;

      _productRepository.AddProduct(product);

      return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
      product.UpdatedAt = DateTime.Now;
      _productRepository.UpdateProduct(product);
    }

    public async Task DeleteProductAsync(int id)
    {
      var product = _productRepository.GetProductById(id);
      if (product != null)
      {
        _productRepository.DeleteProduct(product);
      }
    }

    public async Task<bool> ProductExistsAsync(int id)
    {
      return _productRepository.GetProductById(id) != null;
    }

    public async Task<int> UpdateStockAsync(int productId, int quantity)
    {
      var product = _productRepository.GetProductById(productId);

      if (product == null)
        throw new KeyNotFoundException($"Product with ID {productId} not found.");

      if (product.StockQuantity + quantity < 0)
        throw new InvalidOperationException("Cannot reduce stock below zero.");

      product.StockQuantity += quantity;
      product.UpdatedAt = DateTime.Now;

      _productRepository.UpdateProduct(product);

      return product.StockQuantity;
    }
  }
}
