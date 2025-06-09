using ClinicManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IDoctorRepository : IGenericRepository<Doctor>
  {
    Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(int specializationId);
    Task<Doctor> GetDoctorWithDetailsAsync(int doctorId);
    Task<IEnumerable<Doctor>> GetAvailableDoctorsByDateAndTimeAsync(DateTime date, TimeSpan startTime, TimeSpan endTime);
    Task<IEnumerable<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId);
  }
}
