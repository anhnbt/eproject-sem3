using System;

namespace ClinicManagement.Core.Domain.Entities
{
  public class PrescriptionItem
  {
    public int PrescriptionItemId { get; set; }
    public int PrescriptionId { get; set; }
    public int MedicineId { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
    public int? Duration { get; set; } // in days
    public int Quantity { get; set; }
    public string Instructions { get; set; }

    // Navigation properties
    public Prescription Prescription { get; set; }
    public Medicine Medicine { get; set; }
  }
}
