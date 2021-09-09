using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Dto
{
  public class ErrorDto
  {
    public string Description { get; set; }
    public string ErrorMessage { get; set; }

    public ErrorDto()
    {
    }

    public ErrorDto(string description)
    {
      Description = description;
    }

    public ErrorDto(string description, string content)
    {
      Description = description;
      ErrorMessage = content;
    }

  }
}
