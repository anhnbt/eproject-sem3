using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Interfaces.Services;
using ClinicManagement.Core.Services;
using ClinicManagement.Infrastructure.Data;
using ClinicManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagement.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      // Add DbContext
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

      // Register repositories
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      // Register services
      services.AddScoped<IPatientService, PatientService>();
      services.AddScoped<IDoctorService, DoctorService>();
      services.AddScoped<IAppointmentService, AppointmentService>();

      return services;
    }
  }
}
