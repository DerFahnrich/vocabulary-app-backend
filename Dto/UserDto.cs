using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.Dto
{
  public class UserDto
  {
    public int UserID { get; set; }
    public string Username { get; set; }

    public UserDto(User user)
    {
      UserID = user.UserID;
      Username = user.Username;
    }
  }
}
