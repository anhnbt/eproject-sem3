using System;

namespace ClinicManagement.Core.Domain.Entities
{
  public class DoctorSpecialization
  {
    public int DoctorSpecializationId { get; set; }
    public int DoctorId { get; set; }
    public int SpecializationId { get; set; }

    // Navigation properties
    public Doctor Doctor { get; set; }
    public Specialization Specialization { get; set; }
  }
}
