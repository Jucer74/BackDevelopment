using System.Diagnostics.CodeAnalysis;
using CreditBankAPI.Models;
using Microsoft.EntityFrameworkCore;

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