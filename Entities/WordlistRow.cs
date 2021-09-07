using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Entities
{
  public class WordlistRow
  {
    public int WordListRowId { get; set; }
    public Word Word { get; set; }
    public Wordlist Wordlist { get; set; }
    public DateTime Date { get; set; }
  }
}
