using System;

namespace ClinicManagement.Core.Domain.Entities
{
  public class DoctorSchedule
  {
    public int ScheduleId { get; set; }
    public int DoctorId { get; set; }
    public int DayOfWeek { get; set; } // 0 = Sunday, 1 = Monday, etc.
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsActive { get; set; }

    // Navigation property
    public Doctor Doctor { get; set; }
  }
}
