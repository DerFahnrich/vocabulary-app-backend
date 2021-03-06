using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Context;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IRepositories;

namespace VocabularyAppBackend.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly VocabularyAppBackendContext _context;

    public UserRepository(VocabularyAppBackendContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> CreateUser(User user)
    {
      try
      {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return new CreatedResult($"api/v1/users/{user.UserID}", new UserDto(user));
      }
      catch (Exception error)
      {
        return new BadRequestObjectResult(new ErrorDto("Something went wrong", error.Message));
      }
    }

    public async Task<User> GetUserById(int userId)
    {
      return await _context.Users
        .Where(user => user.UserID == userId)
        .SingleOrDefaultAsync();
    }

    public async Task<UserDto> GetUserByEmail(string email)
    {
      return await _context.Users
        .Where(user => user.Email == email)
        .Select(user => new UserDto(user))
        .SingleOrDefaultAsync();
    }
  }
}
