using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicManagement.Web.Controllers
{
  public class DoctorController : Controller
  {
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
      _doctorService = doctorService;
    }

    // GET: Doctor
    public async Task<IActionResult> Index()
    {
      var doctors = await _doctorService.GetAllDoctorsAsync();
      return View(doctors);
    }

    // GET: Doctor/Details/5
    public async Task<IActionResult> Details(int id)
    {
      var doctor = await _doctorService.GetDoctorWithDetailsAsync(id);
      if (doctor == null)
      {
        return NotFound();
      }

      return View(doctor);
    }

    // GET: Doctor/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Doctor/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Doctor doctor)
    {
      if (ModelState.IsValid)
      {
        await _doctorService.AddDoctorAsync(doctor);
        return RedirectToAction(nameof(Index));
      }
      return View(doctor);
    }

    // GET: Doctor/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var doctor = await _doctorService.GetDoctorByIdAsync(id);
      if (doctor == null)
      {
        return NotFound();
      }
      return View(doctor);
    }

    // POST: Doctor/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Doctor doctor)
    {
      if (id != doctor.DoctorId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _doctorService.UpdateDoctorAsync(doctor);
        }
        catch (Exception)
        {
          if (!await DoctorExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(doctor);
    }

    // GET: Doctor/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var doctor = await _doctorService.GetDoctorByIdAsync(id);
      if (doctor == null)
      {
        return NotFound();
      }

      return View(doctor);
    }

    // POST: Doctor/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _doctorService.DeleteDoctorAsync(id);
      return RedirectToAction(nameof(Index));
    }

    // GET: Doctor/Schedule/5
    public async Task<IActionResult> Schedule(int id)
    {
      var doctor = await _doctorService.GetDoctorByIdAsync(id);
      if (doctor == null)
      {
        return NotFound();
      }

      var schedules = await _doctorService.GetDoctorScheduleAsync(id);
      ViewBag.Doctor = doctor;
      return View(schedules);
    }

    // POST: Doctor/AddSchedule
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddSchedule(DoctorSchedule schedule)
    {
      if (ModelState.IsValid)
      {
        await _doctorService.AddDoctorScheduleAsync(schedule);
        return RedirectToAction(nameof(Schedule), new { id = schedule.DoctorId });
      }
      return RedirectToAction(nameof(Schedule), new { id = schedule.DoctorId });
    }

    private async Task<bool> DoctorExists(int id)
    {
      return await _doctorService.DoctorExistsAsync(id);
    }
  }
}
