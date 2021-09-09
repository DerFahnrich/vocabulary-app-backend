using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Dto;

namespace VocabularyAppBackend.Entities
{
  public class User
  {
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User() { }

    public User(CreateUserDto userToCreate)
    {
      Username = userToCreate.Username;
      Password = userToCreate.Password;
    }
  }
}
