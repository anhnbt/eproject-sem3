using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Product
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public int StockQuantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
  }
}
