using System;
using System.Collections.Generic;
using System.Linq;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
      return _context.Products
          .Include(p => p.Category)
          .Include(p => p.ProductType)
          .ToList();
    }

    public Product GetProductById(int id)
    {
      return _context.Products
          .Include(p => p.Category)
          .Include(p => p.ProductType)
          .FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetProductsByCategory(int categoryId)
    {
      return _context.Products
          .Include(p => p.Category)
          .Include(p => p.ProductType)
          .Where(p => p.CategoryId == categoryId)
          .ToList();
    }

    public IEnumerable<Product> GetProductsByType(int productTypeId)
    {
      return _context.Products
          .Include(p => p.Category)
          .Include(p => p.ProductType)
          .Where(p => p.ProductTypeId == productTypeId)
          .ToList();
    }

    public IEnumerable<Product> SearchProducts(string searchTerm)
    {
      return _context.Products
          .Include(p => p.Category)
          .Include(p => p.ProductType)
          .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
          .ToList();
    }

    public void AddProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
      _context.Products.Update(product);
      _context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
      _context.Products.Remove(product);
      _context.SaveChanges();
    }
  }
}
