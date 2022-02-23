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

    public async Task<IActionResult> CreateUser(UserCreateDto userToCreate)
    {
      if (userToCreate == null)
      {
        return new BadRequestObjectResult(new ErrorDto("Something went wrong"));
      }

      if (string.IsNullOrEmpty(userToCreate.Email) || string.IsNullOrEmpty(userToCreate.Username) || string.IsNullOrEmpty(userToCreate.Password))
      {
        return new BadRequestObjectResult(new ErrorDto("You must provide email, username and password"));
      }

      if (await CheckIfUserExistsByEmail(userToCreate.Email))
      {
        return new BadRequestObjectResult(new ErrorDto("Email already exists"));
      }

      var user = new User(userToCreate);
      user.Password = UserService.s_passwordHasher.HashPassword(user, user.Password);
      return await _repository.CreateUser(user);
    }

    public async Task<User> GetUserById(int userId)
    {
      return await _repository.GetUserById(userId);
    }

    public async Task<UserDto> GetUserByEmail(string email)
    {
      return await _repository.GetUserByEmail(email);
    }

    /*########## Helper Methods Below ##########*/

    private async Task<bool> CheckIfUserExistsByEmail(string email)
    {
      return await GetUserByEmail(email) != null;
    }
  }
}
