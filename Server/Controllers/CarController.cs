using Car.DB;
using Microsoft.AspNetCore.Mvc;
using Software.Service;

namespace Server.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    CarService _carService;
    public CarController(CarService carService)
    {
        _carService = carService;
    }
    [HttpPost("Create")]
    public IResult Create([FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        return Results.Ok(_carService.Create(name, price));
    }

    [HttpPost("FindByID")]
    public IResult FindByID([FromHeader(Name = "Id")] int id)
    {
        return Results.Ok(_carService.FindById(id));
    }

    [HttpGet("FindAll")]
    public IResult FindAll()
    {
        return Results.Ok(_carService.FindAll());
    }

    [HttpDelete("Delete")]
    public IResult DelteByID([FromHeader(Name = "Id")] int id)
    {
        _carService.DeleteById(id);
        return Results.Ok();
    }

    [HttpPatch("Update")]
    public IResult Update([FromHeader(Name = "Id")] int id, [FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        _carService.Update(new() { Id = id, name = name, price = price });
        return Results.Ok();
    }

}
