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
    public string Email { get; set; }
    public string Password { get; set; }

    public User() { }

    public User(UserCreateDto userToCreate)
    {
      Username = userToCreate.Username;
      Password = userToCreate.Password;
      Email = userToCreate.Email;
    }
  }
}
