using System;
using System.Collections.Generic;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IReportRepository
  {
    IEnumerable<Report> GetAllReports();
    Report GetReportById(int id);
    IEnumerable<Report> GetReportsByUser(int userId);
    IEnumerable<Report> GetReportsByType(string reportType);
    void AddReport(Report report);
    void UpdateReport(Report report);
    void DeleteReport(Report report);
  }
}
