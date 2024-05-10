using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
 
using WebTest.Contracts;
using WebTest.DataProviders;
using WebTest.IoCHelpers;
using WebTest.Models.Models;
using WebTest.Services;

namespace WebTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterServices(builder.Configuration);

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
