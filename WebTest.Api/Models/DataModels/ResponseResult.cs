using Newtonsoft.Json;

namespace WebTest.Models.DataModels
{
    public class ResponseResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<Employee> Employees { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
