using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Services
{
  public class DoctorService : IDoctorService
  {
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
    {
      return await _unitOfWork.Doctors.GetAllAsync();
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
      return await _unitOfWork.Doctors.GetByIdAsync(id);
    }

    public async Task<Doctor> GetDoctorWithDetailsAsync(int id)
    {
      return await _unitOfWork.Doctors.GetDoctorWithDetailsAsync(id);
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(int specializationId)
    {
      return await _unitOfWork.Doctors.GetDoctorsBySpecializationAsync(specializationId);
    }

    public async Task<IEnumerable<Doctor>> GetAvailableDoctorsByDateAndTimeAsync(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
      return await _unitOfWork.Doctors.GetAvailableDoctorsByDateAndTimeAsync(date, startTime, endTime);
    }

    public async Task<IEnumerable<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId)
    {
      return await _unitOfWork.Doctors.GetDoctorScheduleAsync(doctorId);
    }

    public async Task<Doctor> AddDoctorAsync(Doctor doctor)
    {
      await _unitOfWork.Doctors.AddAsync(doctor);
      await _unitOfWork.CompleteAsync();

      return doctor;
    }

    public async Task UpdateDoctorAsync(Doctor doctor)
    {
      _unitOfWork.Doctors.Update(doctor);
      await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteDoctorAsync(int id)
    {
      var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
      if (doctor != null)
      {
        _unitOfWork.Doctors.Remove(doctor);
        await _unitOfWork.CompleteAsync();
      }
    }

    public async Task<bool> DoctorExistsAsync(int id)
    {
      return await _unitOfWork.Doctors.ExistsAsync(d => d.DoctorId == id);
    }
    public async Task AddDoctorScheduleAsync(DoctorSchedule schedule)
    {
      await _unitOfWork.DoctorSchedules.AddAsync(schedule);
      await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateDoctorScheduleAsync(DoctorSchedule schedule)
    {
      _unitOfWork.DoctorSchedules.Update(schedule);
      await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteDoctorScheduleAsync(int scheduleId)
    {
      var schedule = await _unitOfWork.DoctorSchedules.GetByIdAsync(scheduleId);
      if (schedule != null)
      {
        _unitOfWork.DoctorSchedules.Remove(schedule);
        await _unitOfWork.CompleteAsync();
      }
    }
  }
}
