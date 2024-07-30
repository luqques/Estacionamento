using Estacionamento.Api;
using Estacionamento.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Layer.Architecture.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//var builder = WebApplication.CreateBuilder(args);

//var connection = builder.Configuration.GetConnectionString("ConnectionStrings:MySqlConnectionString");
//var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

//builder.Services.AddDbContext<MySqlContext>(options =>
//   options.UseMySql(connection, serverVersion));

//builder.Services.AddControllers();

//builder.Services.AddScoped<IBaseService, BaseService>();

//// Add services to the container.
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//});

//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
