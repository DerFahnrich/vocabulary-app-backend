using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IRepositories;
using VocabularyAppBackend.IServices;

namespace VocabularyAppBackend.Services
{
  public class ModeService : IModeService
  {
    private readonly IModeRepository _repository;

    public ModeService(IModeRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<Mode>> GetModes() => await _repository.GetModes();

  }
}
