using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Controllers
{
  [ApiController]
  [Route("api/v1/modes")]
  public class ModeController : ControllerBase
  {
    private readonly IModeService _service;

    public ModeController(IModeService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Mode>>> GetModes()
    {
      return await _service.GetModes();
    }
  }
}
