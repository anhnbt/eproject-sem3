using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicManagement.Web.Controllers
{
  public class AppointmentController : Controller
  {
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;

    public AppointmentController(
        IAppointmentService appointmentService,
        IPatientService patientService,
        IDoctorService doctorService)
    {
      _appointmentService = appointmentService;
      _patientService = patientService;
      _doctorService = doctorService;
    }

    // GET: Appointment
    public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
    {
      startDate ??= DateTime.Today;
      endDate ??= startDate.Value.AddDays(7);

      var appointments = await _appointmentService.GetAppointmentsByDateRangeAsync(
          startDate.Value, endDate.Value);

      ViewBag.StartDate = startDate.Value;
      ViewBag.EndDate = endDate.Value;

      return View(appointments);
    }

    // GET: Appointment/Details/5
    public async Task<IActionResult> Details(int id)
    {
      var appointment = await _appointmentService.GetAppointmentWithDetailsAsync(id);
      if (appointment == null)
      {
        return NotFound();
      }

      return View(appointment);
    }

    // GET: Appointment/Create
    public async Task<IActionResult> Create(int? patientId = null)
    {
      if (patientId.HasValue)
      {
        var patient = await _patientService.GetPatientByIdAsync(patientId.Value);
        if (patient == null)
        {
          return NotFound();
        }

        ViewBag.Patient = patient;
      }

      // Get available doctors
      var doctors = await _doctorService.GetAllDoctorsAsync();
      ViewBag.Doctors = doctors;

      return View();
    }

    // POST: Appointment/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Appointment appointment)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _appointmentService.ScheduleAppointmentAsync(appointment);
          return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
          ModelState.AddModelError("", ex.Message);
        }
      }

      // If we got this far, something failed, redisplay form
      var doctors = await _doctorService.GetAllDoctorsAsync();
      ViewBag.Doctors = doctors;

      // If the appointment has a patient ID, get the patient details
      if (appointment.PatientId > 0)
      {
        var patient = await _patientService.GetPatientByIdAsync(appointment.PatientId);
        ViewBag.Patient = patient;
      }

      return View(appointment);
    }

    // GET: Appointment/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var appointment = await _appointmentService.GetAppointmentWithDetailsAsync(id);
      if (appointment == null)
      {
        return NotFound();
      }

      // Get available doctors
      var doctors = await _doctorService.GetAllDoctorsAsync();
      ViewBag.Doctors = doctors;

      return View(appointment);
    }

    // POST: Appointment/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Appointment appointment)
    {
      if (id != appointment.AppointmentId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        await _appointmentService.UpdateAppointmentAsync(appointment);
        return RedirectToAction(nameof(Index));
      }

      // If we got this far, something failed, redisplay form
      var doctors = await _doctorService.GetAllDoctorsAsync();
      ViewBag.Doctors = doctors;

      return View(appointment);
    }

    // POST: Appointment/Cancel/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id, string reason)
    {
      await _appointmentService.CancelAppointmentAsync(id, reason);
      return RedirectToAction(nameof(Index));
    }

    // POST: Appointment/Complete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Complete(int id)
    {
      await _appointmentService.CompleteAppointmentAsync(id);
      return RedirectToAction(nameof(Index));
    }

    // GET: Appointment/Calendar
    public async Task<IActionResult> Calendar(DateTime? date)
    {
      date ??= DateTime.Today;

      var appointments = await _appointmentService.GetAppointmentsByDateRangeAsync(
          date.Value.AddDays(-7), date.Value.AddDays(30));

      ViewBag.CurrentDate = date.Value;

      return View(appointments);
    }
  }
}
