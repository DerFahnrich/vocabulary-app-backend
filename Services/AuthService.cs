using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VocabularyAppBackend.Constants;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Services
{
  public class AuthService : IAuthService
  {
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly PasswordHasher<User> s_passwordHasher = new PasswordHasher<User>();


    public AuthService(IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
      _userService = userService;
      _httpContextAccessor = httpContextAccessor;
    }

    public Task<IActionResult> ChangePassword(UserChangePasswordDto userToChangePasswordOn) => throw new NotImplementedException();

    public async Task<IActionResult> Login(UserLoginDto userToLogin)
    {
      if (userToLogin == null)
      {
        return new BadRequestObjectResult(new ErrorDto("Something went wrong"));
      }

      if (String.IsNullOrEmpty(userToLogin.Email) || String.IsNullOrEmpty(userToLogin.Password))
      {
        return new BadRequestObjectResult(new ErrorDto("You must provide both email and password"));
      }

      var user = await _userService.GetUserByEmail(userToLogin.Email);
      if (user == null)
      {
        return new BadRequestObjectResult(new ErrorDto("Incorrect email or password"));
      }

      if (!await ValidatePassword(user.UserID, userToLogin.Password))
      {
        return new UnauthorizedObjectResult(new ErrorDto("Incorrect email or password"));
      };

      var claims = new List<Claim>
      {
        new Claim(ClaimConstants.UserId, $"{user.UserID}"),
        new Claim(ClaimConstants.Email, user.Email),
        new Claim(ClaimConstants.Username, user.Username)
      };
      var identity = new ClaimsIdentity(claims, AuthenticationCookie.Name);
      var claimsPrinciple = new ClaimsPrincipal(identity);

      await _httpContextAccessor.HttpContext.SignInAsync(AuthenticationCookie.Name, claimsPrinciple);
      return new OkObjectResult(user);
    }

    public async Task<IActionResult> Logout()
    {
      await _httpContextAccessor.HttpContext.SignOutAsync(AuthenticationCookie.Name);
      return new NoContentResult();
    }

    public async Task<bool> ValidatePassword(int userId, string passwordToValidate)
    {
      var user = await _userService.GetUserById(userId);
      var isPasswordValid = s_passwordHasher.VerifyHashedPassword(user, user.Password, passwordToValidate);
      return isPasswordValid == PasswordVerificationResult.Success ? true : false;
    }

    public IActionResult Whoami()
    {
      var loggedInUserClaims = _httpContextAccessor.HttpContext.User.Claims.ToList();
      var userDto = loggedInUserClaims.Count > 0 ? new UserDto() : null;

      if (userDto != null)
      {
        foreach (var claim in loggedInUserClaims)
        {
          switch (claim.Type)
          {
            case ClaimConstants.Email:
              userDto.Email = claim.Value;
              break;
            case ClaimConstants.UserId:
              userDto.UserID = Int32.Parse(claim.Value);
              break;
            case ClaimConstants.Username:
              userDto.Username = claim.Value;
              break;
          }
        }
      }

      return userDto != null ? new OkObjectResult(userDto) : new NotFoundObjectResult(new ErrorDto("No user logged in"));
    }
  }
}
