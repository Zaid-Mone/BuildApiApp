using BuildApiApp.Models;
using BuildApiApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IGenericRepository<Employee> _employeeRepo;

        public EmployeeController(IGenericRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return _employeeRepo.GetAll();
        }

        [HttpGet("Search")]
        public ActionResult<List<Employee>> Get(string value) // overload 2 action same name diffenernt parameter
        {
            return _employeeRepo.Search(value);
        }


        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(Guid id)
        {
            return _employeeRepo.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employee.Id = new Guid();
            _employeeRepo.Insert(employee);
            _employeeRepo.Save();
            return Ok(new { message="Success"});
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put([FromBody] Employee employee)
        {
            var emp = _employeeRepo.GetById(employee.Id);
            emp.EmployeeName = employee.EmployeeName;
            emp.ProjectId = employee.ProjectId;
            _employeeRepo.Update(emp);
            _employeeRepo.Save();
            return Ok(new { message = "Success" });
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(Guid id)
        {
            var emp = _employeeRepo.GetById(id);
            _employeeRepo.Delete(emp);
            _employeeRepo.Save();
            return Ok(new { message = "Success" });
        }
    }
}
