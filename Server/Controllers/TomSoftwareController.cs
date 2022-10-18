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
    public IResult Create([FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        _tomSoftwareService.Create(new() { Name = name, Price = price });
        return Results.Ok();
    }

    [HttpPost("FindByID")]
    public IResult FindByID([FromHeader(Name = "Id")] int id)
    {
        return Results.Ok(_tomSoftwareService.GetByID(id));
    }

    [HttpGet("FindAll")]
    public IResult FindAll()
    {
        return Results.Ok(_tomSoftwareService.ListAll());
    }

    [HttpDelete("Delete")]
    public IResult DelteByID([FromHeader(Name = "Id")] int id)
    {
        _tomSoftwareService.DeleteByID(id);
        return Results.Ok();
    }

    [HttpPatch("Update")]
    public IResult Update([FromHeader(Name = "Id")] int id, [FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        var dbitem = _tomSoftwareService.GetByID(id);
        if (dbitem == null)
        {
            return Results.NotFound("Item not in Database!");
        }
        dbitem.Name = name;
        dbitem.Price = price;
        _tomSoftwareService.Edit(dbitem);
        return Results.Ok();
    }

}
