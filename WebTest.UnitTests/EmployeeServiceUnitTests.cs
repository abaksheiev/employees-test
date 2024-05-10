using AutoMapper;
using FluentAssertions;
using Moq;
using WebTest.Contracts;
using WebTest.Contracts.Enums;
using WebTest.Models.DataModels;
using WebTest.Services;
using WebTest.UnitTests.Features;
using WebTest.UnitTests.Helpers;

namespace WebTest.UnitTests
{
    public class EmployeeServiceUnitTests
    {
        private IMapper _mapper;
        private Mock<IEmployeeDataProvider> _employeeDataProvideMoc;

        private List<Employee> _employeesDataSet;
        public EmployeeServiceUnitTests()
        {
            _mapper = AutoMapperConfig.Initialize(); // Initialize AutoMapper
            _employeeDataProvideMoc= new Mock<IEmployeeDataProvider>();
            _employeesDataSet = EmployeeInfoDataModelGenerator.GetListFromFile();

            // Mock common services
            _employeeDataProvideMoc.Setup(s => s.GetAllAsync()).Returns(Task.FromResult(_employeesDataSet));
        }
   
        [Fact]
        public async Task WhenGetSortByAge_ShouldBySortedByAge()
        {
            // Expected data
            var expectedResult = _employeesDataSet
                .OrderByDescending(x => x.Age)
                .Take(1)
                .Single();

            // arrange
            var employeeService = new EmployeeService(_employeeDataProvideMoc.Object, _mapper);

            // act
            var result = await employeeService.GetFilterBy(EmployeeFilter.Age);
         
            // assert
            result.Count.Should().BeGreaterThan(0);
            result.First().Id.Should().Be(expectedResult.Id);
        }

        [Fact]
        public async Task WhenGetAll_ShouldReturnAllDataSet()
        {
            // Expected data
            var expectedResult = _employeesDataSet
                .Count();

            // arrange
            var employeeService = new EmployeeService(_employeeDataProvideMoc.Object, _mapper);

            // act
            var result = await employeeService.GetAll();

            // assert
            result.Count.Should().Be(expectedResult);
        }

        [Fact]
        public async Task WhenGetSortByName_ShouldBySortedByName()
        {
            // Expected data
            var expectedResult = _employeesDataSet
                .OrderByDescending(x => x.Name)
                .Take(1)
                .Single();

            // arrange
            var employeeService = new EmployeeService(_employeeDataProvideMoc.Object, _mapper);

            // act
            var result = await employeeService.GetFilterBy(EmployeeFilter.Name);

            // assert
            result.Count.Should().BeGreaterThan(0);
            result.First().Id.Should().Be(expectedResult.Id);
        }

        [Fact]
        public async Task WhenGetSortBySalary_ShouldBySortedBySalary()
        {
            // Expected data
            var expectedResult = _employeesDataSet
                .OrderByDescending(x => x.Salary)
                .Take(1)
                .Single();

            // arrange
            var employeeService = new EmployeeService(_employeeDataProvideMoc.Object, _mapper);

            // act
            var result = await employeeService.GetFilterBy(EmployeeFilter.Salary);

            // assert
            result.Count.Should().BeGreaterThan(0);
            result.First().Id.Should().Be(expectedResult.Id);
        }

    }
}