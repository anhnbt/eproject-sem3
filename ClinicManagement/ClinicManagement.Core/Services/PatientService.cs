using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Services
{
  public class PatientService : IPatientService
  {
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
      return await _unitOfWork.Patients.GetAllAsync();
    }

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
      return await _unitOfWork.Patients.GetByIdAsync(id);
    }

    public async Task<Patient> GetPatientWithDetailsAsync(int id)
    {
      return await _unitOfWork.Patients.GetPatientWithDetailsAsync(id);
    }

    public async Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm)
    {
      return await _unitOfWork.Patients.SearchPatientsAsync(searchTerm);
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(int doctorId)
    {
      return await _unitOfWork.Patients.GetPatientsByDoctorAsync(doctorId);
    }

    public async Task<IEnumerable<Patient>> GetPatientsByAppointmentDateAsync(DateTime date)
    {
      return await _unitOfWork.Patients.GetPatientsByAppointmentDateAsync(date);
    }

    public async Task<Patient> AddPatientAsync(Patient patient)
    {
      patient.CreatedAt = DateTime.Now;
      patient.UpdatedAt = DateTime.Now;

      await _unitOfWork.Patients.AddAsync(patient);
      await _unitOfWork.CompleteAsync();

      return patient;
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
      patient.UpdatedAt = DateTime.Now;

      _unitOfWork.Patients.Update(patient);
      await _unitOfWork.CompleteAsync();
    }

    public async Task DeletePatientAsync(int id)
    {
      var patient = await _unitOfWork.Patients.GetByIdAsync(id);
      if (patient != null)
      {
        _unitOfWork.Patients.Remove(patient);
        await _unitOfWork.CompleteAsync();
      }
    }

    public async Task<bool> PatientExistsAsync(int id)
    {
      return await _unitOfWork.Patients.ExistsAsync(p => p.PatientId == id);
    }
  }
}
