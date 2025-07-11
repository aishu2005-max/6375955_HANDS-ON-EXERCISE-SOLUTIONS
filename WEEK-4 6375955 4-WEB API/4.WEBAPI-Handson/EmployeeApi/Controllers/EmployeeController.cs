using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Static hardcoded list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Salary = 70000 }
        };

        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee newEmployee)
        {
            if (newEmployee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            if (employees.Any(e => e.Id == newEmployee.Id))
            {
                return BadRequest("Employee with given id already exists");
            }

            employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT: api/employee
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            if (updatedEmployee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;

            return Ok(existingEmployee);
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employees.Remove(employee);
            return Ok($"Employee with id {id} deleted successfully");
        }
    }
}