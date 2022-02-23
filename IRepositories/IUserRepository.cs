using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.IRepositories
{
  public interface IUserRepository
  {
    Task<User> GetUserById(int userId);
    Task<UserDto> GetUserByEmail(string email);
    Task<IActionResult> CreateUser(User user);
  }
}
