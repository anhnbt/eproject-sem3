using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using ClinicManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<User> GetAllUsers()
    {
      return _context.Users.Include(u => u.Role).ToList();
    }

    public User GetUserById(int id)
    {
      return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
    }

    public User GetUserByEmail(string email)
    {
      return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
    }

    public User GetUserByUsername(string username)
    {
      return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username);
    }

    public void AddUser(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
      _context.Users.Remove(user);
      _context.SaveChanges();
    }

    public bool UserExists(string email)
    {
      return _context.Users.Any(u => u.Email == email);
    }
  }
}
