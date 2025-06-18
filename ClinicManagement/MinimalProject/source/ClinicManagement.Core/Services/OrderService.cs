using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Core.Interfaces.Services;

namespace ClinicManagement.Core.Services
{
  public class OrderService : IOrderService
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
      _orderRepository = orderRepository;
      _productRepository = productRepository;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
      return _orderRepository.GetAllOrders();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
      return _orderRepository.GetOrderById(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId)
    {
      return _orderRepository.GetOrdersByUser(userId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status)
    {
      return _orderRepository.GetOrdersByStatus(status);
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
      // Set timestamps
      order.CreatedAt = DateTime.Now;
      order.UpdatedAt = DateTime.Now;

      // Set initial status
      if (string.IsNullOrEmpty(order.Status))
      {
        order.Status = "Pending";
      }

      // Calculate total price based on order items
      if (order.OrderItems != null && order.OrderItems.Count > 0)
      {
        decimal totalAmount = 0;

        foreach (var item in order.OrderItems)
        {
          var product = _productRepository.GetProductById(item.ProductId);
          if (product == null)
          {
            throw new KeyNotFoundException($"Product with ID {item.ProductId} not found.");
          }

          if (product.StockQuantity < item.Quantity)
          {
            throw new InvalidOperationException($"Not enough stock for product '{product.Name}'. Available: {product.StockQuantity}");
          }

          item.UnitPrice = product.Price;
          item.TotalPrice = item.UnitPrice * item.Quantity;

          // Update stock quantity
          product.StockQuantity -= item.Quantity;
          _productRepository.UpdateProduct(product);

          totalAmount += item.TotalPrice;

          // Set created/updated timestamps for each item
          item.CreatedAt = DateTime.Now;
          item.UpdatedAt = DateTime.Now;
        }

        order.TotalAmount = totalAmount;
      }

      _orderRepository.AddOrder(order);

      return order;
    }

    public async Task UpdateOrderAsync(Order order)
    {
      order.UpdatedAt = DateTime.Now;
      _orderRepository.UpdateOrder(order);
    }

    public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
    {
      var order = _orderRepository.GetOrderById(orderId);
      if (order == null)
        return false;

      order.Status = status;
      order.UpdatedAt = DateTime.Now;

      _orderRepository.UpdateOrder(order);
      return true;
    }

    public async Task DeleteOrderAsync(int id)
    {
      var order = _orderRepository.GetOrderById(id);
      if (order != null)
      {
        _orderRepository.DeleteOrder(order);
      }
    }
  }
}
