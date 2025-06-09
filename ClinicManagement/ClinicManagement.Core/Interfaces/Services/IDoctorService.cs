using ClinicManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IDoctorService
  {
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<Doctor> GetDoctorWithDetailsAsync(int id);
    Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(int specializationId);
    Task<IEnumerable<Doctor>> GetAvailableDoctorsByDateAndTimeAsync(DateTime date, TimeSpan startTime, TimeSpan endTime);
    Task<IEnumerable<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId);
    Task<Doctor> AddDoctorAsync(Doctor doctor);
    Task UpdateDoctorAsync(Doctor doctor);
    Task DeleteDoctorAsync(int id);
    Task<bool> DoctorExistsAsync(int id);
    Task AddDoctorScheduleAsync(DoctorSchedule schedule);
    Task UpdateDoctorScheduleAsync(DoctorSchedule schedule);
    Task DeleteDoctorScheduleAsync(int scheduleId);
  }
}
