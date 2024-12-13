using Microsoft.EntityFrameworkCore;
using SWVUEL.Infrastructure.Contracts;
using SWVUEL.Infrastructure.Impl;
using SWVUEL.Infrastructure.Impl.DbContexts;
using SWVUEL.Library.Contracts;
using System.Text.Json;
using SWVUEL.Library.Impl;

namespace SWVUEL.DistributedService.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("YourDatabaseName");
            builder.Services.AddDbContext<StarshipDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IService, Service>();
            builder.Services.AddHttpClient<IRepository, Repository>();

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
