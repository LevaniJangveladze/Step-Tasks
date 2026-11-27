using CarsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    public static List<Car> _cars = new List<Car>()
    {
        new Car { Brand = "BMW", Model = "X5", Year = 2020 },
        new Car { Brand = "Toyota", Model = "Prius", Year = 2018 },
        new Car { Brand = "Mercedes", Model = "C200", Year = 2022 },
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_cars);
    }

    [HttpGet("{carId}")]
    public IActionResult GetById(string carId)
    {
        var car = _cars.FirstOrDefault(c => c.Id == carId);
        
        if (car == null) return NotFound("Car not found.");

        return Ok(car);
    }

    [HttpPost]
    public IActionResult Create(Car car)
    {
        _cars.Add(car);
        return Ok(car);
    }

    [HttpPut("{carId}")]
    public IActionResult Updated(string carId, Car updatedCar)
    {
        var car = _cars.FirstOrDefault(c => c.Id ==  carId);
        
        if (car == null) return NotFound("Car not found.");

        car.Brand = updatedCar.Brand;
        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        return Ok(car);
    }

    [HttpDelete("{carId}")]
    public IActionResult Delete(string carId)
    {
        var car = _cars.FirstOrDefault(c => c.Id == carId);

        if (car == null) return NotFound("Car not found. ");
        
        _cars.Remove(car);
        return Ok(car);
    }
}