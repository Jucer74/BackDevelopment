using CreditBank.Api.DataAccess;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración del DbContext.
var connectionString = builder.Configuration.GetConnectionString("CreditCardsDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Scope
builder.Services.AddScoped<ReportedCardDataAccess>();
builder.Services.AddScoped<ReportedCardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
