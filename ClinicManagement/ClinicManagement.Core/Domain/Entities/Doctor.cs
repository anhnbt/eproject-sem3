using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public string LicenseNumber { get; set; }
    public int? Experience { get; set; }
    public string Biography { get; set; }
    public string EducationBackground { get; set; }
    public bool IsAvailable { get; set; }

    // Navigation properties
    public User User { get; set; }
    public ICollection<DoctorSpecialization> Specializations { get; set; }
    public ICollection<DoctorSchedule> Schedules { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<PatientRecord> PatientRecords { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
  }
}
