using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IRepositories;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    private readonly static PasswordHasher<User> s_passwordHasher = new PasswordHasher<User>();

    public UserService(IUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<IActionResult> CreateUser(CreateUserDto userToCreate)
    {
      if (userToCreate == null)
      {
        return new BadRequestObjectResult(new ErrorDto("Something went wrong"));
      }

      if (String.IsNullOrEmpty(userToCreate.Username) || String.IsNullOrEmpty(userToCreate.Password))
      {
        return new BadRequestObjectResult(new ErrorDto("You must provide both username and password"));
      }

      if (await CheckIfUserExistsByUsername(userToCreate.Username))
      {
        return new BadRequestObjectResult(new ErrorDto("Username already exists"));
      }

      var user = new User(userToCreate);
      user.Password = UserService.s_passwordHasher.HashPassword(user, user.Password);
      return await _repository.CreateUser(user);
    }

    public async Task<UserDto> GetUserById(int userId)
    {
      return await _repository.GetUserById(userId);
    }

    public async Task<UserDto> GetUserByUsername(string username)
    {
      return await _repository.GetUserByUsername(username);
    }

    /*########## Helper Methods Below ##########*/

    private async Task<bool> CheckIfUserExistsByUsername(string username)
    {
      return await GetUserByUsername(username) != null;
    }
  }
}
