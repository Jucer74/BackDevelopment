using Microsoft.EntityFrameworkCore;
using StudentsAPI.Context;
using StudentsAPI.Exceptions;
using System;

async Task ExceptionMiddleware(HttpContext context, Func<Task> next)
{
    try
    {
        await next.Invoke();
    }
    catch (NotFoundException nfe)
    {
        context.Response.StatusCode = 404; // Not Found
        await context.Response.WriteAsync(nfe.Message);
    }
    catch (BadRequestException bre)
    {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync(bre.Message);
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500; // Internal Server Error
        await context.Response.WriteAsync($"An unexpected error occurred: {ex.Message}");
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppdbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("CnnStr")!));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(ExceptionMiddleware);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
