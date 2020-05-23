using Microsoft.AspNetCore.Mvc;
using PaylocityChallenge.BLL;
using PaylocityChallenge.Objects;

namespace PaylocityChallenge.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_employeeService.GetAll());
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult GetById(int id)
        {
            return new JsonResult(_employeeService.GetById(id));
        }

        [HttpPost, Route("add")]
        public IActionResult Add(EmployeeDTO employee)
        {
            var addedEmployee = _employeeService.Add(employee);
            return new CreatedAtRouteResult("GetEmployee", new { id = addedEmployee.Id }, addedEmployee);
        }

        [HttpPut, Route("update")]
        public IActionResult Update(EmployeeDTO employee)
        {
            _employeeService.Update(employee);
            return new NoContentResult();
        }
    }
}