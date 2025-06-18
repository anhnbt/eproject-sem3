using System;
using System.Collections.Generic;
using System.Linq;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class ReportRepository : IReportRepository
  {
    private readonly ApplicationDbContext _context;

    public ReportRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Report> GetAllReports()
    {
      return _context.Reports
          .Include(r => r.User)
          .ToList();
    }

    public Report GetReportById(int id)
    {
      return _context.Reports
          .Include(r => r.User)
          .FirstOrDefault(r => r.Id == id);
    }

    public IEnumerable<Report> GetReportsByUser(int userId)
    {
      return _context.Reports
          .Include(r => r.User)
          .Where(r => r.UserId == userId)
          .ToList();
    }

    public IEnumerable<Report> GetReportsByType(string reportType)
    {
      return _context.Reports
          .Include(r => r.User)
          .Where(r => r.ReportType == reportType)
          .ToList();
    }

    public void AddReport(Report report)
    {
      _context.Reports.Add(report);
      _context.SaveChanges();
    }

    public void UpdateReport(Report report)
    {
      _context.Reports.Update(report);
      _context.SaveChanges();
    }

    public void DeleteReport(Report report)
    {
      _context.Reports.Remove(report);
      _context.SaveChanges();
    }
  }
}
