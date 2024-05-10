using AutoMapper;
using WebTest.Models.ApiDtos;
using WebTest.Models.DataModels;

namespace WebTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<EmployeeApiDto, Employee>();

            CreateMap<Employee, EmployeeApiDto>();
        }
    }
}
