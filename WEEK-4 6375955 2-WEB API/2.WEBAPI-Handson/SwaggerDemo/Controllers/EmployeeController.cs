
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MySwaggerDemo.Controllers
{
    [ApiController]
    [Route("api/Emp")] // Custom route name
    public class EmployeeController : ControllerBase
    {
        // In-memory employee list
        private static readonly List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new Employee { Id = 2, Name = "Bob", Email = "bob@example.com" }
        };

        // GET: api/Emp
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        // GET: api/Emp/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // POST: api/Emp
        [HttpPost]
        public IActionResult Post([FromBody] Employee newEmp)
        {
            if (employees.Any(e => e.Id == newEmp.Id))
                return Conflict("Employee with this ID already exists.");

            employees.Add(newEmp);
            return CreatedAtAction(nameof(Get), new { id = newEmp.Id }, newEmp);
        }

        // PUT: api/Emp/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee updatedEmp)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            emp.Name = updatedEmp.Name;
            emp.Email = updatedEmp.Email;

            return NoContent();
        }

        // DELETE: api/Emp/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            employees.Remove(emp);
            return NoContent();
        }
    }

    // Model class
    public class Employee
    {
        public int Id { get; set; }              // Unique ID
        public string Name { get; set; } = "";   // Employee name
        public string Email { get; set; } = "";  // Employee email
    }
}