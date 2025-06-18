using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IOrderService
  {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<IEnumerable<Order>> GetOrdersByUserAsync(int userId);
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task<bool> UpdateOrderStatusAsync(int orderId, string status);
    Task DeleteOrderAsync(int id);
  }
}
