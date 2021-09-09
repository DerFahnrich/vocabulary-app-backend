using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Context;
using VocabularyAppBackend.Entities;
using VocabularyAppBackend.IRepositories;

namespace VocabularyAppBackend.Repositories
{
  public class ModeRepository : IModeRepository
  {

    private readonly VocabularyAppBackendContext _context;

    public ModeRepository(VocabularyAppBackendContext context)
    {
      _context = context;
    }

    public async Task<List<Mode>> GetModes() => await _context.Modes.ToListAsync();
  }
}
