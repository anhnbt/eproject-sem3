using System;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Payment
  {
    public int PaymentId { get; set; }
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int PaymentMethodId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string ReferenceNumber { get; set; }
    public string Status { get; set; } // Paid, Pending, Failed, Refunded
    public string Notes { get; set; }

    // Navigation properties
    public Appointment Appointment { get; set; }
    public Patient Patient { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
  }
}
