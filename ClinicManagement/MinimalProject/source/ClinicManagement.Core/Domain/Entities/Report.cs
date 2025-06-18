using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Report
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ReportType { get; set; } // Sales, Inventory, Customer, etc.

    public string Parameters { get; set; } // JSON string of parameters

    [Required]
    [StringLength(20)]
    public string Format { get; set; } // PDF, Excel, etc.

    public DateTime GeneratedAt { get; set; }

    public int GeneratedById { get; set; }
    public User GeneratedBy { get; set; }
  }
}
