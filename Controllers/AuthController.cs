using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Controllers
{
  [ApiController]
  [Route("api/v1/auth")]
  public class AuthController
  {
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
      _service = service;
    }

    [HttpGet("whoami")]
    public IActionResult Whoami()
    {
      return _service.Whoami();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userToLogin)
    {
      return await _service.Login(userToLogin);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
      return await _service.Logout();
    }
  }
}
