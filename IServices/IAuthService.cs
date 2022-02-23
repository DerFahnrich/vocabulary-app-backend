using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;

namespace VocabularyAppBackend.IServices
{
  public interface IAuthService
  {
    Task<IActionResult> Login(UserLoginDto userToLogin);
    Task<IActionResult> Logout();
    Task<IActionResult> ChangePassword(UserChangePasswordDto userToChangePasswordOn);
    Task<bool> ValidatePassword(int userId, string passwordToValidate);
    IActionResult Whoami();
  }
}
