using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Software.Service;
using TomSoftware.Service;
using WorkShopContext;
using WorkShopContext.Models;

namespace Server.Controllers;

[ApiController]
[Route("api/TomSoftware")]
public class TomSoftwareController : ControllerBase
{
    private ITomSoftwareService _tomSoftwareService;

    public TomSoftwareController(ITomSoftwareService tomSoftwareService)
    {
        _tomSoftwareService = tomSoftwareService;
    }

    [HttpPost("Create")]
    public IResult Create()
    {
        //var _db = _contextFactory.CreateDbContext();
        //_db.Database.EnsureCreated();
        //var databaseCreator = _db.GetService<IRelationalDatabaseCreator>();
        //databaseCreator.CreateTables();
        return Results.Ok();
    }

    [HttpPost("Test")]
    public IResult Test()
    {
        _tomSoftwareService.DoIt();
        return Results.Ok();
    }

    //[HttpPost("FindByID")]
    //public IResult FindByID([FromHeader(Name = "Id")] int id)
    //{
    //    return Results.Ok(_softwareService.FindById(id));
    //}

    //[HttpGet("FindAll")]
    //public IResult FindAll()
    //{
    //    return Results.Ok(_s);
    //}

    //[HttpDelete("Delete")]
    //public IResult DelteByID([FromHeader(Name = "Id")] int id)
    //{
    //    _softwareService.DeleteById(id);
    //    return Results.Ok();
    //}

    //[HttpPatch("Update")]
    //public IResult Update([FromHeader(Name = "Id")] int id, [FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    //{
    //    _softwareService.Update(new() { Id = id, name = name, price = price });
    //    return Results.Ok();
    //}

}
