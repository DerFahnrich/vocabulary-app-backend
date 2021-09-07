using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocabularyAppBackend.Entities
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string EnglishTitle { get; set; }
    public string SwedishTitle { get; set; }
    public string? Icon { get; set; }
    public Category? ParentCategory { get; set; }
  }
}
