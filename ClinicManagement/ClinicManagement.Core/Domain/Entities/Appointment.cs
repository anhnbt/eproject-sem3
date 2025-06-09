using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public int Duration { get; set; } // in minutes
    public string Status { get; set; } // Scheduled, Completed, Cancelled, No-Show
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<AppointmentService> Services { get; set; }
    public Payment Payment { get; set; }
  }
}
