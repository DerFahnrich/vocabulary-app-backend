using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.IServices
{
  public interface IUserService
  {
    Task<User> GetUserById(int userId);
    Task<UserDto> GetUserByEmail(string email);
    Task<IActionResult> CreateUser(UserCreateDto userToCreate);
  }
}
