using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Dto
{
  public class UserChangePasswordDto
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
  }
}
