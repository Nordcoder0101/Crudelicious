using Microsoft.EntityFrameworkCore;

namespace Crudelicious.Models
{
  public class CrudeliciousContext : DbContext
  {
    public CrudeliciousContext(DbContextOptions<CrudeliciousContext> options) : base(options){}
    public DbSet<Dishes> Dishes {get;set;}
  }
}