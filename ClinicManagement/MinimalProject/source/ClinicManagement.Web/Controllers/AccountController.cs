using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicManagement.Web.Controllers
{
  [Authorize]
  public class AccountController : Controller
  {
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
      _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
      return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      // Here would be authentication logic

      return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
      return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      // Here would be registration logic

      return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
      // Here would be sign out logic

      return RedirectToAction("Index", "Home");
    }

    public IActionResult Profile()
    {
      // Here would be logic to get the current user profile

      return View();
    }

    [HttpPost]
    public IActionResult Profile(UserProfileViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      // Here would be profile update logic

      return RedirectToAction("Profile");
    }
  }
}
