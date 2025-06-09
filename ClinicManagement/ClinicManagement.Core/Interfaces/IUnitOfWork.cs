using ClinicManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ClinicManagement.Core.Interfaces.Repositories;

namespace ClinicManagement.Core.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    // Access to the DbContext
    DbContext Context { get; }

    // Repositories
    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IAppointmentRepository Appointments { get; }
    IGenericRepository<Medicine> Medicines { get; }
    IGenericRepository<Prescription> Prescriptions { get; }
    IGenericRepository<PrescriptionItem> PrescriptionItems { get; }
    IGenericRepository<Service> Services { get; }
    IGenericRepository<Payment> Payments { get; }
    IGenericRepository<User> Users { get; }
    IGenericRepository<Role> Roles { get; }
    IGenericRepository<UserRole> UserRoles { get; }
    IGenericRepository<PatientRecord> PatientRecords { get; }
    IGenericRepository<DoctorSchedule> DoctorSchedules { get; }
    IGenericRepository<Specialization> Specializations { get; }

    // Transaction management
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
  }
}
