using System;
using System.Linq;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.OpenApi.Models;
using CreditBank.Api.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditBank.Api
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllers();
         services.AddScoped<ReportedCardDataAccess>();
         services.AddDbContext<AppDbContext>(options => options.UseSqlite("Name=CreditBankDB"));
         services.AddScoped<ReportedCardService>();
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CreditBank.Api", Version = "v1" });
         });
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditBank.Api v1"));
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}