using Microsoft.EntityFrameworkCore;
using MoneyBankAPI.Models;

namespace MoneyBankAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
