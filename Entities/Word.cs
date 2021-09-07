using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Entities
{
  public class Word
  {
    public int WordId { get; set; }
    public string English { get; set; }
    public string Swedish { get; set; }
    public int Difficulty { get; set; }
    public Category Category { get; set; }

  }
}
