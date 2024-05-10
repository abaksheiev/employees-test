using System.ComponentModel.DataAnnotations;
using WebTest.Contracts.Enums;

namespace WebTest.Controllers.Models
{
    public class EmployeeRequestModel
    {
        [Required]
        [EnumDataType(typeof(EmployeeFilter), ErrorMessage = "Invalid value for SortedField.( Valid: ['Age', 'Salary','Name'])")]
        public string Sort { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Skip must be a positive integer.")]
        public int Skip { get; set; } = 0;

        [Range(1, 100, ErrorMessage = "Limit must be between 1 and 100.")]
        public int Limit { get; set; } = 1;
    }
}
