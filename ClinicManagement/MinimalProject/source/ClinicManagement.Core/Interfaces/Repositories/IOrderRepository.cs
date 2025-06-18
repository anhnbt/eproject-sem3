using System;
using System.Collections.Generic;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IOrderRepository
  {
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int id);
    IEnumerable<Order> GetOrdersByUser(int userId);
    IEnumerable<Order> GetOrdersByStatus(string status);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);
  }
}
