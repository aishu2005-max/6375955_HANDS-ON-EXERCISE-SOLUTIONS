using Microsoft.AspNetCore.Mvc;
using MyEmployeeApi.Models;
using MyEmployeeApi.Filters;

namespace MyEmployeeApi.Controllers;

[ApiController]
[Route("api/Emp")]
[ServiceFilter(typeof(CustomAuthFilter))]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees;

    public EmployeeController()
    {
        if (employees == null)
            employees = GetStandardEmployeeList();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<Employee>> Get()
    {
        // Uncomment to test exception handling
        throw new Exception("Simulated exception");
       // return Ok(employees);
    }

    [HttpGet("standard")]
    public ActionResult<Employee> GetStandard()
    {
        return Ok(employees.FirstOrDefault());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee emp)
    {
        employees.Add(emp);
        return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee emp)
    {
        var existing = employees.FirstOrDefault(e => e.Id == id);
        if (existing == null) return NotFound();

        existing.Name = emp.Name;
        return Ok(existing);
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 60000,
                Permanent = true,
                DateOfBirth = new DateTime(1990, 5, 1),
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                }
            }
        };
    }
}