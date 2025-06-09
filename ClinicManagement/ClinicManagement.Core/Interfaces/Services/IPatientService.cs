using ClinicManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IPatientService
  {
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
    Task<Patient> GetPatientByIdAsync(int id);
    Task<Patient> GetPatientWithDetailsAsync(int id);
    Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm);
    Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(int doctorId);
    Task<IEnumerable<Patient>> GetPatientsByAppointmentDateAsync(DateTime date);
    Task<Patient> AddPatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient);
    Task DeletePatientAsync(int id);
    Task<bool> PatientExistsAsync(int id);
  }
}
