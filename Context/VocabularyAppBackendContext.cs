using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Entities;

namespace VocabularyAppBackend.Context
{
  public class VocabularyAppBackendContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Mode> Modes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Wordlist> Wordlists { get; set; }
    public DbSet<WordlistRow> WordlistRows { get; set; }

    public VocabularyAppBackendContext(DbContextOptions<VocabularyAppBackendContext> options) : base(options)
    {
    }
  }
}
