<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
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
<<<<<<< HEAD
}
=======
}
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
