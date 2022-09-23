using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AccountApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AccountApi.Controllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IHttpContextAccessor _contextAccessor;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpContextAccessor contextAccessor)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
    }
    [HttpGet]
    [Route("get-all")]
    public ActionResult<object> Get()
    {


        if (_contextAccessor.HttpContext != null)
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "exp")?.Value;
            var types = _contextAccessor.HttpContext.User.Claims.Select(x => x.Type);


            return Ok(new
            {
                claimsIdentity = new DateTime(),
                types

            });
        }
        return Ok("fail");
    }
}
