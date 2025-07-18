using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    public AuthController(IConfiguration config) => _config = config;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "test" && model.Password == "password")
        {
            var token = GenerateJwtToken(model.Username);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }

    [Authorize]
    [HttpGet("secure")]
    public IActionResult SecureData() => Ok(new { message = "This is a protected endpoint" });

    private string GenerateJwtToken(string username)
    {
        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:DurationInMinutes"])),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}