using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CreditBank.Api.Models;

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

