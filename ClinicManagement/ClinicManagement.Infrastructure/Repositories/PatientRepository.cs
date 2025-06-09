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
  public class PatientRepository : GenericRepository<Patient>, IPatientRepository
  {
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(int doctorId)
    {
      return await _context.Appointments
          .Where(a => a.DoctorId == doctorId)
          .Select(a => a.Patient)
          .Distinct()
          .ToListAsync();
    }

    public async Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm))
        return await GetAllAsync();

      searchTerm = searchTerm.Trim().ToLower();

      return await _context.Patients
          .Where(p => p.FirstName.ToLower().Contains(searchTerm) ||
                     p.LastName.ToLower().Contains(searchTerm) ||
                     p.PhoneNumber.Contains(searchTerm) ||
                     (p.Email != null && p.Email.ToLower().Contains(searchTerm)))
          .ToListAsync();
    }

    public async Task<Patient> GetPatientWithDetailsAsync(int patientId)
    {
      return await _context.Patients
          .Include(p => p.User)
          .Include(p => p.PatientRecords)
          .Include(p => p.Appointments)
              .ThenInclude(a => a.Doctor)
                  .ThenInclude(d => d.User)
          .Include(p => p.Prescriptions)
              .ThenInclude(pr => pr.PrescriptionItems)
                  .ThenInclude(pi => pi.Medicine)
          .FirstOrDefaultAsync(p => p.PatientId == patientId);
    }

    public async Task<IEnumerable<Patient>> GetPatientsByAppointmentDateAsync(DateTime date)
    {
      return await _context.Appointments
          .Where(a => a.ScheduledDate.Date == date.Date)
          .Select(a => a.Patient)
          .Distinct()
          .ToListAsync();
    }
  }
}
