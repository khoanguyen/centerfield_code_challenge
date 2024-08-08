using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json.Linq;
using CoffeeShopApi.Model;

namespace CoffeeShopApi.Controllers;

[ApiController]
[Route("coffee-shop")]
public class CoffeeShopController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<CoffeeShopController> _logger;

    public CoffeeShopController(ILogger<CoffeeShopController> logger)
    {
        _logger = logger;        
    }

    [HttpGet, Route("")]
    public IEnumerable<CoffeeShop> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new CoffeeShop {
            Id = 1,
            Name = "Shop1",
            OpeningTime = TimeOnly.Parse("8:00"),
            ClosingTime = TimeOnly.Parse("20:00")            
        })
        .ToArray();
    }
    
    [HttpPost, Route("")]
    public CoffeeShop Post(CoffeeShop payload)
    {
        return payload;
    }

    [HttpPut, Route("{id:int}")]
    public WeatherForecast Put([FromRoute]int id, [FromBody]WeatherForecast payload)
    {
        return null;
    }

    [HttpDelete, Route("{id:int}")]
    public WeatherForecast Delete([FromRoute]int id)
    {
        return null;
    }

    /// <summary>
    /// Patches CoffeeShop with given id, usage reference https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-8.0 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    [HttpPatch, Route("{id:int}")]
    public WeatherForecast Patch([FromRoute]int id, [FromBody]JsonPatchDocument<WeatherForecast> payload)
    {
        var entity = new WeatherForecast();
        payload.ApplyTo(entity, ModelState);
        return entity;
    }
}
