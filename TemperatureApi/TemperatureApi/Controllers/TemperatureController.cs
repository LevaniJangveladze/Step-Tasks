using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TemperatureController : ControllerBase
{
    private readonly ITemperatureConverter _converter;
    public TemperatureController(ITemperatureConverter converter) => _converter = converter;
 
    [HttpGet]
    public decimal Get(decimal celsius)
    {
        return _converter.Convert(celsius);
    }
}