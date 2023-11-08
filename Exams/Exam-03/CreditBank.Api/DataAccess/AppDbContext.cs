using CreditBank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditBank.Api.DataAccess
{
   public class AppDbContext : DbContext
   {
      public AppDbContext()
      {
      }

      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
      }

      public DbSet<ReportedCard> ReportedCards { get; set; }
   }
}
