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
  public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
  {
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(int specializationId)
    {
      return await _context.DoctorSpecializations
          .Where(ds => ds.SpecializationId == specializationId)
          .Select(ds => ds.Doctor)
          .Include(d => d.User)
          .ToListAsync();
    }

    public async Task<Doctor> GetDoctorWithDetailsAsync(int doctorId)
    {
      return await _context.Doctors
          .Include(d => d.User)
          .Include(d => d.Specializations)
              .ThenInclude(ds => ds.Specialization)
          .Include(d => d.Schedules)
          .Include(d => d.Appointments)
              .ThenInclude(a => a.Patient)
          .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
    }

    public async Task<IEnumerable<Doctor>> GetAvailableDoctorsByDateAndTimeAsync(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
      // Get day of week (0 = Sunday, 1 = Monday, etc.)
      int dayOfWeek = (int)date.DayOfWeek;

      // Get doctors who have schedules for that day and time
      var availableDoctorIds = await _context.DoctorSchedules
          .Where(ds => ds.DayOfWeek == dayOfWeek &&
                     ds.StartTime <= startTime &&
                     ds.EndTime >= endTime &&
                     ds.IsActive)
          .Select(ds => ds.DoctorId)
          .ToListAsync();

      // Get existing appointments that might conflict with requested time
      var bookedDoctorIds = await _context.Appointments
          .Where(a => a.ScheduledDate.Date == date.Date &&
                    ((a.ScheduledTime <= startTime && a.ScheduledTime.Add(TimeSpan.FromMinutes(a.Duration)) > startTime) ||
                     (a.ScheduledTime >= startTime && a.ScheduledTime < endTime)) &&
                    a.Status != "Cancelled" && a.Status != "No-Show")
          .Select(a => a.DoctorId)
          .ToListAsync();

      // Filter out doctors who already have appointments during requested time
      var finalDoctorIds = availableDoctorIds.Except(bookedDoctorIds).ToList();

      return await _context.Doctors
          .Include(d => d.User)
          .Include(d => d.Specializations)
              .ThenInclude(ds => ds.Specialization)
          .Where(d => finalDoctorIds.Contains(d.DoctorId) && d.IsAvailable)
          .ToListAsync();
    }

    public async Task<IEnumerable<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId)
    {
      return await _context.DoctorSchedules
          .Where(ds => ds.DoctorId == doctorId && ds.IsActive)
          .ToListAsync();
    }
  }
}
