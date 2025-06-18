using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using ClinicManagement.Core.Interfaces.Services;

namespace ClinicManagement.Core.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
      // Implementation would be async in a real application
      return _userRepository.GetAllUsers();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
      return _userRepository.GetUserById(id);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
      return _userRepository.GetUserByEmail(email);
    }

    public async Task<User> AuthenticateAsync(string email, string password)
    {
      // Implementation would include password verification logic
      var user = _userRepository.GetUserByEmail(email);

      if (user == null)
        return null;

      // Here would be password verification logic
      // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
      //    return null;

      return user;
    }

    public async Task<User> RegisterUserAsync(User user, string password)
    {
      // Implementation would include password hashing
      // CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
      // user.PasswordHash = passwordHash;
      // user.PasswordSalt = passwordSalt;

      user.CreatedAt = DateTime.Now;
      user.UpdatedAt = DateTime.Now;

      _userRepository.AddUser(user);

      return user;
    }

    public async Task UpdateUserAsync(User user)
    {
      user.UpdatedAt = DateTime.Now;
      _userRepository.UpdateUser(user);
    }

    public async Task DeleteUserAsync(int id)
    {
      var user = _userRepository.GetUserById(id);
      if (user != null)
      {
        _userRepository.DeleteUser(user);
      }
    }

    public async Task<bool> UserExistsAsync(string email)
    {
      return _userRepository.UserExists(email);
    }

    // Private helper methods for password hashing would go here
  }
}
