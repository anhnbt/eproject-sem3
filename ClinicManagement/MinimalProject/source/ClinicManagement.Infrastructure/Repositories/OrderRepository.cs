using System;
using System.Collections.Generic;
using System.Linq;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class OrderRepository : IOrderRepository
  {
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Order> GetAllOrders()
    {
      return _context.Orders
          .Include(o => o.User)
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .Include(o => o.Payment)
          .ToList();
    }

    public Order GetOrderById(int id)
    {
      return _context.Orders
          .Include(o => o.User)
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .Include(o => o.Payment)
          .FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<Order> GetOrdersByUser(int userId)
    {
      return _context.Orders
          .Include(o => o.User)
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .Include(o => o.Payment)
          .Where(o => o.UserId == userId)
          .ToList();
    }

    public IEnumerable<Order> GetOrdersByStatus(string status)
    {
      return _context.Orders
          .Include(o => o.User)
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .Include(o => o.Payment)
          .Where(o => o.Status == status)
          .ToList();
    }

    public void AddOrder(Order order)
    {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
      _context.Orders.Update(order);
      _context.SaveChanges();
    }

    public void DeleteOrder(Order order)
    {
      _context.Orders.Remove(order);
      _context.SaveChanges();
    }
  }
}
