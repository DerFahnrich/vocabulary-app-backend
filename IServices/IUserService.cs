using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;

namespace VocabularyAppBackend.IServices
{
  public interface IUserService
  {
    Task<UserDto> GetUserById(int userId);
    Task<UserDto> GetUserByUsername(string username);
    Task<IActionResult> CreateUser(CreateUserDto userToCreate);
  }
}
