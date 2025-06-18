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
  [Authorize]
  public class OrdersController : Controller
  {
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public OrdersController(
        ILogger<OrdersController> logger,
        IOrderService orderService,
        IProductService productService)
    {
      _logger = logger;
      _orderService = orderService;
      _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
      try
      {
        // Get orders for the current user
        var userId = GetCurrentUserId();
        var orders = await _orderService.GetOrdersByUserAsync(userId);
        return View(orders);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading orders");
        return View("Error");
      }
    }

    public async Task<IActionResult> Details(int id)
    {
      try
      {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
          return NotFound();
        }

        // Check if the order belongs to the current user (unless admin/staff)
        var userId = GetCurrentUserId();
        if (order.UserId != userId && !User.IsInRole("Admin") && !User.IsInRole("Staff"))
        {
          return Forbid();
        }

        return View(order);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error occurred while loading order details for ID: {id}");
        return View("Error");
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
      try
      {
        var product = await _productService.GetProductByIdAsync(productId);
        if (product == null)
        {
          return NotFound();
        }

        // Here would be logic to add the product to the shopping cart
        // For simplicity, assuming we have a cart service or session-based cart

        return RedirectToAction("Cart");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error occurred while adding product ID {productId} to cart");
        return View("Error");
      }
    }

    public IActionResult Cart()
    {
      try
      {
        // Here would be logic to get the current shopping cart
        // For simplicity, assuming we have a cart service or session-based cart

        return View();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading shopping cart");
        return View("Error");
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout()
    {
      try
      {
        // Here would be logic to create an order from the shopping cart
        // For simplicity, assuming we have a cart service or session-based cart

        return RedirectToAction("Confirmation");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred during checkout");
        return View("Error");
      }
    }

    public IActionResult Confirmation()
    {
      return View();
    }

    [Authorize(Roles = "Admin,Staff")]
    public async Task<IActionResult> AllOrders()
    {
      try
      {
        var orders = await _orderService.GetAllOrdersAsync();
        return View(orders);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while loading all orders");
        return View("Error");
      }
    }

    [Authorize(Roles = "Admin,Staff")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
      try
      {
        await _orderService.UpdateOrderStatusAsync(id, status);
        return RedirectToAction("AllOrders");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error occurred while updating status for order ID: {id}");
        return View("Error");
      }
    }

    private int GetCurrentUserId()
    {
      // In a real application, this would get the ID from the current user's claims
      // For simplicity, returning a placeholder
      return 1;
    }
  }
}
