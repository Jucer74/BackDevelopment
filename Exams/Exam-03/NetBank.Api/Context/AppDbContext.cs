using Microsoft.EntityFrameworkCore;
using NetBank.Api.Models;

namespace NetBank.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<IssuingNetwork> IssuingNetworks { get; set; }
}