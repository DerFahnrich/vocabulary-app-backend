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
    Task<UserDto> GetUserById(int userId);
    Task<UserDto> GetUserByUsername(string username);
    Task<IActionResult> CreateUser(User user);
  }
}
