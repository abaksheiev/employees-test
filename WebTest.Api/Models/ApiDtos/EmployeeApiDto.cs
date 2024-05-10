using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebTest.Models.ApiDtos
{
    public class EmployeeApiDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string Name { get; set; }

        [JsonPropertyName("employee_salary")]
        public string Salary { get; set; }

        [JsonPropertyName("employee_age")]
        public int Age { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }
    }
}
