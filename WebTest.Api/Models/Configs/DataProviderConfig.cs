namespace WebTest.Models.Models
{
    public record DataProviderConfig
    {
        public const string SectionName = "DataProviders";
        public string? EmployeeUrl { get; set; }
    }
}
