using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.IRepositories
{
  public interface IModeRepository
  {
    public Task<List<Mode>> GetModes();
  }
}
