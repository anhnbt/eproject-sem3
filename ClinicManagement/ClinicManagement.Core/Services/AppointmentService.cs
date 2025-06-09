using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Services
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
      return await _unitOfWork.Appointments.GetAppointmentsByDateRangeAsync(startDate, endDate);
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
    {
      return await _unitOfWork.Appointments.GetAppointmentsByDoctorAndDateAsync(doctorId, date);
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId)
    {
      return await _unitOfWork.Appointments.GetAppointmentsByPatientAsync(patientId);
    }

    public async Task<Appointment> GetAppointmentWithDetailsAsync(int appointmentId)
    {
      return await _unitOfWork.Appointments.GetAppointmentWithDetailsAsync(appointmentId);
    }

    public async Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
      return await _unitOfWork.Appointments.IsDoctorAvailableAsync(doctorId, date, startTime, endTime);
    }

    public async Task<Appointment> ScheduleAppointmentAsync(Appointment appointment)
    {
      // Validate doctor availability
      bool isAvailable = await _unitOfWork.Appointments.IsDoctorAvailableAsync(
          appointment.DoctorId,
          appointment.ScheduledDate,
          appointment.ScheduledTime,
          appointment.ScheduledTime.Add(TimeSpan.FromMinutes(appointment.Duration))
      );

      if (!isAvailable)
      {
        throw new InvalidOperationException("The doctor is not available at the specified time.");
      }

      // Set appointment default values
      appointment.Status = "Scheduled";
      appointment.CreatedAt = DateTime.Now;
      appointment.UpdatedAt = DateTime.Now;

      await _unitOfWork.Appointments.AddAsync(appointment);
      await _unitOfWork.CompleteAsync();

      return appointment;
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
      appointment.UpdatedAt = DateTime.Now;
      _unitOfWork.Appointments.Update(appointment);
      await _unitOfWork.CompleteAsync();
    }

    public async Task CancelAppointmentAsync(int appointmentId, string reasonForCancellation)
    {
      var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
      if (appointment == null)
      {
        throw new KeyNotFoundException($"Appointment with ID {appointmentId} not found.");
      }

      appointment.Status = "Cancelled";
      appointment.Notes = appointment.Notes + "\nCancellation Reason: " + reasonForCancellation;
      appointment.UpdatedAt = DateTime.Now;

      _unitOfWork.Appointments.Update(appointment);
      await _unitOfWork.CompleteAsync();
    }

    public async Task CompleteAppointmentAsync(int appointmentId)
    {
      var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
      if (appointment == null)
      {
        throw new KeyNotFoundException($"Appointment with ID {appointmentId} not found.");
      }

      appointment.Status = "Completed";
      appointment.UpdatedAt = DateTime.Now;

      _unitOfWork.Appointments.Update(appointment);
      await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(int days)
    {
      DateTime startDate = DateTime.Today;
      DateTime endDate = startDate.AddDays(days);

      var appointments = await _unitOfWork.Appointments.GetAppointmentsByDateRangeAsync(startDate, endDate);
      return appointments.Where(a => a.Status == "Scheduled");
    }
  }
}
