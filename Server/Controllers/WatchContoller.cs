using Microsoft.AspNetCore.Mvc;
using Watch.Api;
using Watch.Impl;
using System.Net.Mime;
namespace Watchs.Controllers;

[ApiController]
[Route("[controller]")]
public class WatchController : ControllerBase
{
    private readonly WatchOperations _WatchOperations;
    public WatchController(WatchOperations watchOperations)
    {
        this._WatchOperations = watchOperations;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<int> Create([FromHeader(Name = "name")]string name, [FromHeader(Name = "price")]double price)
    {
        try
        {
            return _WatchOperations.Create(name, price);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }

    [HttpGet("id")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Watch.Api.Watch> FindById([FromHeader(Name = "id")]int id)
    {
        try
        {
            return _WatchOperations.FindById(id);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Watch.Api.Watch>> FindAll()
    {
        try
        {
            return _WatchOperations.FindAll();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPut]
    [Consumes("application/json")]
    public ActionResult Update([FromBody]Watch.Api.Watch watch)
    {
        try
        {
            _WatchOperations.Update(watch);
            return new EmptyResult();
        }
        catch
        {
             return UnprocessableEntity();
        }
    }

    [HttpDelete]
    public ActionResult Delete([FromHeader(Name = "id")]int id)
    {
        try
        {
            _WatchOperations.DeleteById(id);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
}