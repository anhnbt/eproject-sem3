using System;
using System.Collections.Generic;

namespace ClinicManagement.Core.Domain.Entities
{
  public class User
  {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public ICollection<UserRole> UserRoles { get; set; }
    public Doctor Doctor { get; set; }

    public string FullName => $"{FirstName} {LastName}";
  }
}
