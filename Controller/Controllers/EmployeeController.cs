using Business.Employee.Contract;
using Domain.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controller.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<EmployeeDTO> result = (await _employeeBusiness.GetEmployees()).ToList();
                result.ForEach(employee => employee.EmployeeSalary = _employeeBusiness.GetEmployeeAnualSalary(employee));

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return new ObjectResult(Array.Empty<EmployeeDTO>())
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet]
        [Route("employees/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                EmployeeDTO result = await _employeeBusiness.GetEmployeeById(id);

                if (result is null)
                {
                    return new NotFoundObjectResult(result);
                }

                result.EmployeeSalary = _employeeBusiness.GetEmployeeAnualSalary(result);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}