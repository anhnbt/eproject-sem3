using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Patient
  {
    public int PatientId { get; set; }
    public int? UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string BloodType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyContactPhone { get; set; }
    public string MedicalInsuranceNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public ICollection<PatientRecord> PatientRecords { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<Payment> Payments { get; set; }

    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Today.Year - DateOfBirth.Year -
        (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
  }
}
