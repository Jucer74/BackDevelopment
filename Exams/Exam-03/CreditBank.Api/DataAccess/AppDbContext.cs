using CreditBank.Api.Models;
using System;
using System.Collections.Generic;

using System.Linq;
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
