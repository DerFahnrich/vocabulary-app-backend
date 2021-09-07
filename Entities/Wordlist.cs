using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Entities
{
  public class Wordlist
  {
    public int WordlistId { get; set; }
    public string Name { get; set; }
    public bool DefaultWordlist { get; set; }
    public User User { get; set; }
  }
}
