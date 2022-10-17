using Microsoft.AspNetCore.Mvc;
using Software.Service;
using TomSoftware.Service;
using WorkShopContext;

namespace Server.Controllers;

[ApiController]
[Route("api/TomSoftware")]
public class TomSoftwareController : ControllerBase
{
    TomSoftwareService<WorkShopDBContext> _db;
    public TomSoftwareController(TomSoftwareService<WorkShopDBContext> softwareService)
    {
        _db = softwareService;
    }
    [HttpPost("Create")]
    public IResult Create([FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        _db.DoIt();
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
    //    return Results.Ok(_softwareService.FindAll());
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
