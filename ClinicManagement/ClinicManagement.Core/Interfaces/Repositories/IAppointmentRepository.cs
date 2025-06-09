using ClinicManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IAppointmentRepository : IGenericRepository<Appointment>
  {
    Task<IEnumerable<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date);
    Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId);
    Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId);
    Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime date, TimeSpan startTime, TimeSpan endTime);
  }
}
