using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IReportService
  {
    Task<Report> GenerateSalesReportAsync(DateTime startDate, DateTime endDate, int userId, string format);
    Task<Report> GenerateInventoryReportAsync(int userId, string format);
    Task<Report> GenerateCustomerReportAsync(DateTime startDate, DateTime endDate, int userId, string format);
    Task<IEnumerable<Report>> GetReportHistoryAsync(int userId);
    Task<Report> GetReportByIdAsync(int id);
  }
}
