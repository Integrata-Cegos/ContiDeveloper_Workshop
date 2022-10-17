using Microsoft.AspNetCore.Mvc;
using Software.Service;

namespace Server.Controllers;

[ApiController]
[Route("api/software")]
public class SoftwareController : ControllerBase
{
    SoftwareService _softwareService;
    public SoftwareController(SoftwareService softwareService)
    {
        _softwareService = softwareService;
    }
    [HttpPost("Create")]
    public IResult Create([FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        return Results.Ok(_softwareService.Create(name, price));
    }

    [HttpPost("FindByID")]
    public IResult FindByID([FromHeader(Name = "Id")] int id)
    {
        return Results.Ok(_softwareService.FindById(id));
    }

    [HttpGet("FindAll")]
    public IResult FindAll()
    {
        return Results.Ok(_softwareService.FindAll());
    }

    [HttpDelete("Delete")]
    public IResult DelteByID([FromHeader(Name = "Id")] int id)
    {
        _softwareService.DeleteById(id);
        return Results.Ok();
    }

    [HttpPatch("Update")]
    public IResult Update([FromHeader(Name = "Id")] int id, [FromHeader(Name = "Name")] string name, [FromHeader(Name = "Price")] double price)
    {
        _softwareService.Update(new() { Id = id, name = name, price = price });
        return Results.Ok();
    }

}
