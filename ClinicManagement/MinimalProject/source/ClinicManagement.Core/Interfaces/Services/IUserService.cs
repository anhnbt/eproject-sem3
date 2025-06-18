using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Services
{
  public interface IUserService
  {
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> AuthenticateAsync(string email, string password);
    Task<User> RegisterUserAsync(User user, string password);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task<bool> UserExistsAsync(string email);
  }
}
