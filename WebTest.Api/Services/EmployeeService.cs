using AutoMapper;
using WebTest.Contracts;
using WebTest.Contracts.Enums;
using WebTest.Models.ApiDtos;
using WebTest.Models.DataModels;


namespace WebTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDataProvider _employeeDataProvider;
        private IMapper _mapper;

        // Define sorting functions and store them in a dictionary
        Dictionary<EmployeeFilter, Func<Employee, object>> sortingFunctions =
            new()
                {
                    { EmployeeFilter.Age, p => p.Age },
                    { EmployeeFilter.Name, p => p.Name },
                    { EmployeeFilter.Salary, p => p.Salary }
                };

        public EmployeeService(IEmployeeDataProvider employeeRepository, IMapper mapper)
        {
            _employeeDataProvider = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<EmployeeApiDto>> GetAll()
        {
            var data = await _employeeDataProvider.GetAllAsync();
            var employeeApiDto = _mapper.Map<List<EmployeeApiDto>>(data);

            return employeeApiDto;
        }

        public async Task<List<EmployeeApiDto>> GetFilterBy(EmployeeFilter filter, int skip = 0, int limit = 1)
        {
            var data = await _employeeDataProvider.GetAllAsync();

            var filetedData = data
                    .OrderByDescending(sortingFunctions[filter])
                    .Skip(skip)
                    .Take(limit)
                    .ToList();

            var employeeApiDto = _mapper.Map<List<EmployeeApiDto>>(filetedData);

            return employeeApiDto;
        }

    }
}
