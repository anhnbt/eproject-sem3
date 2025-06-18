using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Services;
using ClinicManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Web.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(
        ILogger<HomeController> logger,
        IProductService productService)
    {
      _logger = logger;
      _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
      try
      {
        var featuredProducts = await _productService.GetFeaturedProductsAsync();
        var viewModel = new HomeViewModel
        {
          FeaturedProducts = featuredProducts
        };

        return View(viewModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading homepage");
        return View("Error");
      }
    }

    public IActionResult About()
    {
      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
