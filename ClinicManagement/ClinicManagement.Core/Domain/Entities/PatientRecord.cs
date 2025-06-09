using System;

namespace ClinicManagement.Core.Domain.Entities
{
  public class PatientRecord
  {
    public int RecordId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime RecordDate { get; set; }
    public string Symptoms { get; set; }
    public string Diagnosis { get; set; }
    public string Notes { get; set; }

    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
  }
}
