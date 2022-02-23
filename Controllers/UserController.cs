using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Controllers
{
  [Route("api/v1/users")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
      _service = service;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserById(int userId)
    {
      var user = await _service.GetUserById(userId);
      return user != null ? new UserDto(user) : NotFound(new ErrorDto("User could not be found"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateDto userToCreate)
    {
      return await _service.CreateUser(userToCreate);
    }
  }
}
