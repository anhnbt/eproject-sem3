using System;
using System.Collections.Generic;
using ClinicManagement.Core.Domain.Entities;

namespace ClinicManagement.Core.Interfaces.Repositories
{
  public interface IUserRepository
  {
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    User GetUserByEmail(string email);
    User GetUserByUsername(string username);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    bool UserExists(string email);
  }
}
