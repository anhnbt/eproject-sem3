using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClinicManagement.Web.Models;
using ClinicManagement.Core.Interfaces.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;

    public HomeController(
        ILogger<HomeController> logger,
        IAppointmentService appointmentService,
        IPatientService patientService,
        IDoctorService doctorService)
    {
        _logger = logger;
        _appointmentService = appointmentService;
        _patientService = patientService;
        _doctorService = doctorService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            // Get data for dashboard
            var upcomingAppointments = await _appointmentService.GetUpcomingAppointmentsAsync(7);
            ViewBag.UpcomingAppointments = upcomingAppointments;

            // Get today's appointments
            var todayAppointments = await _appointmentService.GetAppointmentsByDateRangeAsync(
                DateTime.Today, DateTime.Today);
            ViewBag.TodayAppointments = todayAppointments;

            // Get counts for dashboard summary
            var allPatients = await _patientService.GetAllPatientsAsync();
            var allDoctors = await _doctorService.GetAllDoctorsAsync();

            ViewBag.PatientCount = allPatients.Count;
            ViewBag.DoctorCount = allDoctors.Count;
            ViewBag.TodayAppointmentCount = todayAppointments.Count;
            ViewBag.UpcomingAppointmentCount = upcomingAppointments.Count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard data");
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
