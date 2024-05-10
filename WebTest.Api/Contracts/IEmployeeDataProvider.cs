using WebTest.Models.DataModels;

namespace WebTest.Contracts
{
    public interface IEmployeeDataProvider
    {
        Task<List<Employee>> GetAllAsync();
    }
}
