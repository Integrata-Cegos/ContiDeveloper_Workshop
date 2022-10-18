using Car.Api;
using Car.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Collections.Generic;
using System.Net;
using System.Web;
namespace Server.Controllers;

[ApiController]
[Route("api/car")]
public class CarController: ControllerBase
{
    private readonly ICarOperations _carService;

    public CarController(ICarOperations carService)
    {
        _carService = carService;
    }

    [HttpGet("byId")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Car.Api.Car> FindCarById([FromHeader(Name = "id")] int id){
        try
        {
            return _carService.FindById(id);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<int> CreateCar([FromHeader(Name="name")] string name, [FromHeader(Name="price")]double price){
         return _carService.Create(name, price);
    }

    [HttpDelete]
    public ActionResult DeleteCarById([FromHeader(Name = "id")]int id)
    {
        _carService.DeleteById(id);
        return new EmptyResult();
    }
    [HttpGet("all")]
    public ActionResult<List<Car.Api.Car>> FindAllCars()
    {
        var cars = _carService.FindAll();
        if (cars.Count == 0){
            return NotFound();
        }else{
            return cars;
        }
    }


    [HttpPut]
    public ActionResult UpdateCare(Car.Api.Car car)
    {
        _carService.Update(car);
        return new EmptyResult();
    }
  
}