using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Web.Controllers
{
  public class ProductsController : Controller
  {
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(
        ILogger<ProductsController> logger,
        IProductService productService,
        ICategoryService categoryService)
    {
      _logger = logger;
      _productService = productService;
      _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(int? categoryId, string searchTerm)
    {
      try
      {
        IEnumerable<Product> products;

        if (!string.IsNullOrEmpty(searchTerm))
        {
          products = await _productService.SearchProductsAsync(searchTerm);
          ViewData["SearchTerm"] = searchTerm;
        }
        else if (categoryId.HasValue)
        {
          products = await _productService.GetProductsByCategoryAsync(categoryId.Value);
          ViewData["CategoryId"] = categoryId.Value;
        }
        else
        {
          products = await _productService.GetAllProductsAsync();
        }

        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewData["Categories"] = categories;

        return View(products);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading products");
        return View("Error");
      }
    }

    public async Task<IActionResult> Details(int id)
    {
      try
      {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
          return NotFound();
        }

        return View(product);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error occurred while loading product details for ID: {id}");
        return View("Error");
      }
    }

    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> Create()
    {
      try
      {
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewData["Categories"] = categories;

        return View();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading create product form");
        return View("Error");
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> Create(Product product)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _productService.AddProductAsync(product);
          return RedirectToAction(nameof(Index));
        }

        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewData["Categories"] = categories;

        return View(product);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while creating product");
        return View("Error");
      }
    }
  }
}
