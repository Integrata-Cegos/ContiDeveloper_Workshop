using Television.Impl;
using Television.Api;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Television.Controller;

[ApiController]
[Route("[controller]")]
public class TelevisionController : ControllerBase
{
    private readonly Television.Impl.TelevisionManager _televisionManager;

    public TelevisionController(Television.Impl.TelevisionManager TelevisionManager)
    {
        _televisionManager = TelevisionManager;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<int> Create([FromHeader(Name="Name")] string name, [FromHeader(Name="Price")] double price)
    {
        try
        {
            return _televisionManager.Create(name, price);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }

    [HttpGet("id")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Television.Api.Television> FindById([FromHeader(Name="Id")] int id)
    {
        try
        {
            return _televisionManager.FindById(id);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet("all")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Television.Api.Television>> FindAll()
    {
        try
        {
            return _televisionManager.FindAll();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPut]
    [Consumes("application/json")]
    public ActionResult Update([FromBody] Television.Api.Television Television)
    {
        try
        {
            _televisionManager.Update(Television);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }
    }

    [HttpDelete]
    public ActionResult Delete([FromHeader(Name="Id")] int id)
    {
        try
        {
            _televisionManager.DeleteById(id);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
}