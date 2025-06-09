using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Infrastructure.Data;
using ClinicManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    private IPatientRepository _patientRepository;
    private IDoctorRepository _doctorRepository;
    private IAppointmentRepository _appointmentRepository;
    private IGenericRepository<Medicine> _medicineRepository;
    private IGenericRepository<Prescription> _prescriptionRepository;
    private IGenericRepository<PrescriptionItem> _prescriptionItemRepository;
    private IGenericRepository<Service> _serviceRepository;
    private IGenericRepository<Payment> _paymentRepository;
    private IGenericRepository<User> _userRepository;
    private IGenericRepository<Role> _roleRepository;
    private IGenericRepository<UserRole> _userRoleRepository;
    private IGenericRepository<PatientRecord> _patientRecordRepository;
    private IGenericRepository<DoctorSchedule> _doctorScheduleRepository;
    private IGenericRepository<Specialization> _specializationRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public IPatientRepository Patients =>
        _patientRepository ??= new PatientRepository(_context);

    public IDoctorRepository Doctors =>
        _doctorRepository ??= new DoctorRepository(_context);

    public IAppointmentRepository Appointments =>
        _appointmentRepository ??= new AppointmentRepository(_context);

    public IGenericRepository<Medicine> Medicines =>
        _medicineRepository ??= new GenericRepository<Medicine>(_context);

    public IGenericRepository<Prescription> Prescriptions =>
        _prescriptionRepository ??= new GenericRepository<Prescription>(_context);

    public IGenericRepository<PrescriptionItem> PrescriptionItems =>
        _prescriptionItemRepository ??= new GenericRepository<PrescriptionItem>(_context);

    public IGenericRepository<Service> Services =>
        _serviceRepository ??= new GenericRepository<Service>(_context);

    public IGenericRepository<Payment> Payments =>
        _paymentRepository ??= new GenericRepository<Payment>(_context);

    public IGenericRepository<User> Users =>
        _userRepository ??= new GenericRepository<User>(_context);

    public IGenericRepository<Role> Roles =>
        _roleRepository ??= new GenericRepository<Role>(_context);

    public IGenericRepository<UserRole> UserRoles =>
        _userRoleRepository ??= new GenericRepository<UserRole>(_context); public IGenericRepository<PatientRecord> PatientRecords =>
        _patientRecordRepository ??= new GenericRepository<PatientRecord>(_context);

    public IGenericRepository<DoctorSchedule> DoctorSchedules =>
        _doctorScheduleRepository ??= new GenericRepository<DoctorSchedule>(_context);

    public IGenericRepository<Specialization> Specializations =>
        _specializationRepository ??= new GenericRepository<Specialization>(_context);

    public DbContext Context => _context;

    public async Task<int> CompleteAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
      _transaction = await _context.Database.BeginTransactionAsync();
    }
    public async Task CommitTransactionAsync()
    {
      if (_transaction == null)
        return;

      try
      {
        await _transaction.CommitAsync();
      }
      finally
      {
        await _transaction.DisposeAsync();
        _transaction = null;
      }
    }

    public async Task RollbackTransactionAsync()
    {
      if (_transaction == null)
        return;

      try
      {
        await _transaction.RollbackAsync();
      }
      finally
      {
        await _transaction.DisposeAsync();
        _transaction = null;
      }
    }

    public void Dispose()
    {
      _transaction?.Dispose();
      _context.Dispose();
    }
  }
}
