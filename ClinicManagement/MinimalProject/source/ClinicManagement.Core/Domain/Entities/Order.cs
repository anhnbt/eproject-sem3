using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Order
  {
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public decimal TotalAmount { get; set; }

    [StringLength(20)]
    public string Status { get; set; } // Processing, Shipped, Delivered, etc.

    public DateTime OrderDate { get; set; }

    [StringLength(200)]
    public string ShippingAddress { get; set; }

    [StringLength(50)]
    public string TrackingNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    public Payment Payment { get; set; }
  }
}
