using ClinicManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IPatientRepository : IGenericRepository<Patient>
  {
    Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(int doctorId);
    Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm);
    Task<Patient> GetPatientWithDetailsAsync(int patientId);
    Task<IEnumerable<Patient>> GetPatientsByAppointmentDateAsync(DateTime date);
  }
}
