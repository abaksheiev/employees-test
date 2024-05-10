using Microsoft.AspNetCore.Hosting;
using WebTest.Contracts;
using WebTest.DataProviders;
using WebTest.Models.Models;
using WebTest.Services;

namespace WebTest.IoCHelpers
{
    public static class ServicesExtenstions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();

            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeDataProvider, EmployeeDataProvider>();
            
            services.AddHttpClient();
            services.AddAutoMapper(typeof(Program));

            // Configure options using appsettings.json
            services.Configure<DataProviderConfig>(configuration.GetSection(DataProviderConfig.SectionName));
        }
    }
}
