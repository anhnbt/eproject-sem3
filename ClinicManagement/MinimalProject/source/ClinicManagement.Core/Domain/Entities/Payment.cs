using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Payment
  {
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentMethod { get; set; }

    [StringLength(100)]
    public string TransactionId { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } // Pending, Completed, Failed, etc.

    public DateTime PaymentDate { get; set; }
  }
}
