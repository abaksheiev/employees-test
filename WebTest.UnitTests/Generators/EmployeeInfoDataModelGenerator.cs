using Bogus;
using Newtonsoft.Json;
using WebTest.Models.DataModels;

namespace WebTest.UnitTests.Features
{
    internal static class EmployeeInfoDataModelGenerator
    {
        public static readonly string EmployeesTestDataPath = "TestData\\Employees.json";

        public static List<Employee> GetListFromFile() {
            // Get the current directory where the application is running
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the current directory with the relative path to your JSON file
            string relativePath = Path.Combine(currentDirectory, EmployeesTestDataPath);

            // Read JSON file contents
            string jsonContent = File.ReadAllText(relativePath);

            // Deserialize JSON array to list of Employee objects
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(jsonContent);

            return employees;
        }
    }
}
