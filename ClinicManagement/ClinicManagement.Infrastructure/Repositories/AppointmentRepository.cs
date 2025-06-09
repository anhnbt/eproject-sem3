using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
  {
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
      return await _context.Appointments
          .Include(a => a.Patient)
          .Include(a => a.Doctor)
              .ThenInclude(d => d.User)
          .Where(a => a.ScheduledDate >= startDate.Date && a.ScheduledDate <= endDate.Date)
          .OrderBy(a => a.ScheduledDate)
          .ThenBy(a => a.ScheduledTime)
          .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
    {
      return await _context.Appointments
          .Include(a => a.Patient)
          .Where(a => a.DoctorId == doctorId && a.ScheduledDate.Date == date.Date)
          .OrderBy(a => a.ScheduledTime)
          .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId)
    {
      return await _context.Appointments
          .Include(a => a.Doctor)
              .ThenInclude(d => d.User)
          .Include(a => a.Services)
              .ThenInclude(s => s.Service)
          .Where(a => a.PatientId == patientId)
          .OrderByDescending(a => a.ScheduledDate)
          .ThenBy(a => a.ScheduledTime)
          .ToListAsync();
    }

    public async Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId)
    {
      return await _context.Appointments
          .Include(a => a.Patient)
          .Include(a => a.Doctor)
              .ThenInclude(d => d.User)
          .Include(a => a.Services)
              .ThenInclude(s => s.Service)
          .Include(a => a.Payment)
          .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
    }

    public async Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
      // Check if doctor has a schedule for that day
      int dayOfWeek = (int)date.DayOfWeek;
      bool hasSchedule = await _context.DoctorSchedules
          .AnyAsync(ds => ds.DoctorId == doctorId &&
                       ds.DayOfWeek == dayOfWeek &&
                       ds.StartTime <= startTime &&
                       ds.EndTime >= endTime &&
                       ds.IsActive);

      if (!hasSchedule)
        return false;

      // Check if doctor has existing appointments that conflict with this time slot
      bool hasConflictingAppointments = await _context.Appointments
          .AnyAsync(a => a.DoctorId == doctorId &&
                      a.ScheduledDate.Date == date.Date &&
                      ((a.ScheduledTime <= startTime && a.ScheduledTime.Add(TimeSpan.FromMinutes(a.Duration)) > startTime) ||
                       (a.ScheduledTime >= startTime && a.ScheduledTime < endTime)) &&
                      a.Status != "Cancelled" && a.Status != "No-Show");

      // Doctor is available if they have a schedule and no conflicting appointments
      return !hasConflictingAppointments;
    }
  }
}
