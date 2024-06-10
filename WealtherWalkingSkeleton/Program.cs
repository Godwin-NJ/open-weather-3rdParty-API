using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WealtherWalkingSkeleton.DTO;
using WealtherWalkingSkeleton.Services;

namespace WealtherWalkingSkeleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;
            var openWeatherConfig = builder.Configuration.GetSection("OpenWeatherApiKey");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<OpenWeather>(openWeatherConfig);
            builder.Services.AddScoped<IOpenWeatherService, OpenWeatherService>();
            builder.Services.AddHttpClient();

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
        }
    }
}
