using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebTest.Contracts;
using WebTest.Models.DataModels;
using WebTest.Models.Models;

namespace WebTest.DataProviders
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DataProviderConfig _config;

        private List<Employee> _employees = [];

        public EmployeeDataProvider(IOptions<DataProviderConfig> configs, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _config = configs?.Value ?? throw new ArgumentNullException(nameof(configs));
        }
        async Task<List<Employee>> IEmployeeDataProvider.GetAllAsync()
        {
            // Caching employees due to Security: "TooManyRequests"
            if (!_employees.Any())
            {
                _employees = await LoadEmployees(); 
            }
           
            return _employees;
        }

        private async Task<List<Employee>> LoadEmployees()
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                // Make an HTTP GET request
                HttpResponseMessage response = await client.GetAsync(_config.EmployeeUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseResult>(responseBody);
                    return result.Employees;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
        }
    }
}