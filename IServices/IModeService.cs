using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.IServices

{
  public interface IModeService
  {
    public Task<List<Mode>> GetModes();
  }
}
