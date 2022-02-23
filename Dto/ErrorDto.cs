using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Dto
{
  public class ErrorDto
  {
    public string Error { get; set; }
    public string ErrorMessage { get; set; }

    public ErrorDto()
    {
    }

    public ErrorDto(string error)
    {
      Error = error;
    }

    public ErrorDto(string error, string errorMessage)
    {
      Error = error;
      ErrorMessage = errorMessage;
    }

  }
}
