using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTest.Contracts;
using WebTest.Contracts.Enums;
using WebTest.Controllers.Models;
using WebTest.Models;
using WebTest.Models.ApiDtos;
using WebTest.Models.DataModels;

namespace WebTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;

        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }


        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var data = await _employeeService.GetAll();
                var response = ResponseResult<List<EmployeeApiDto>>.BuildSuccess(data);

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseResult<string>.BuildError(ex.Message));
            }
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> GetEmployeesByFilter([FromQuery] EmployeeRequestModel model)
        {
            try
            {
                var data = await _employeeService.GetFilterBy(Enum.Parse<EmployeeFilter>(model.Sort), model.Skip, model.Limit);
                var response = new ResponseResult<List<EmployeeApiDto>>(data, "success", "Successfully! Record has been fetched.");

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseResult<string>.BuildError(ex.Message));
            }
        }
    }
}
