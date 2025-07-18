using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]
        [Authorize] // Only accessible with valid JWT token
        public IActionResult GetSecureData()
        {
            return Ok(new { message = "This is protected data, only accessible with a valid token!" });
        }
    }
}