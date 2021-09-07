using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Entities
{
  public class Mode
  {
    public int ModeId { get; set; }
    public bool Active { get; set; }
    public string ModeName { get; set; }
    public string EnglishTitle { get; set; }
    public string SwedishTitle { get; set; }
    public string? Icon { get; set; }
  }
}
