using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Web.Models
{
  public class UserProfileViewModel
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    public string Address { get; set; }
  }
}
