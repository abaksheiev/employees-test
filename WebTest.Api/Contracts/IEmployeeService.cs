using WebTest.Contracts.Enums;
using WebTest.Models.ApiDtos;

namespace WebTest.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeApiDto>> GetAll();
        Task<List<EmployeeApiDto>> GetFilterBy(EmployeeFilter filter, int numberByOrder = 1, int numberOfRecords = 1);
    }
}
