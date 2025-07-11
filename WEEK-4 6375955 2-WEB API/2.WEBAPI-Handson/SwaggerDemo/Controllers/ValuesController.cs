using Microsoft.AspNetCore.Mvc;

namespace MySwaggerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> values = new() { "value1", "value2" };

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        // GET: api/values/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            return Ok(values[id]);
        }

        // POST: api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }

        // PUT: api/values/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            values[id] = value;
            return NoContent();
        }

        // DELETE: api/values/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound();
            values.RemoveAt(id);
            return NoContent();
        }
    }
}