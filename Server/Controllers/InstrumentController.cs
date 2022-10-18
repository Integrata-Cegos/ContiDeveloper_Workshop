using Microsoft.AspNetCore.Mvc;
using Instrument.Api;
using System.Net.Mime;
namespace Instruments.Controllers;

[ApiController]
[Route("[controller]")]
public class InstrumentsController : ControllerBase
{
    private readonly IInstrumentOperations _Manager;
    public InstrumentsController(IInstrumentOperations manager)
    {
        this._Manager = manager;
    }
    [HttpPost]
    public ActionResult<int> Create([FromHeader(Name = "name")] string name, [FromHeader(Name = "price")] double price)
    {
        try
        {
            return _Manager.Create(name, price);
        }
        catch
        {
            return UnprocessableEntity();
        }

    }
    [HttpPut]
    [Consumes("application/json")]
    public ActionResult Update([FromBody] Instrument.Api.Instrument instrument)
    {
        {
            try
            {
                _Manager.Update(instrument);
                return new EmptyResult();
            }
            catch
            {
                return UnprocessableEntity();
            }

        }

    }
    [HttpDelete]
    public ActionResult Delete([FromHeader(Name = "id")] int id)
    {
        try
        {
            _Manager.DeleteById(id);
            return new EmptyResult();
        }
        catch
        {
            return UnprocessableEntity();
        }

    }
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]

    public ActionResult<List<Instrument.Api.Instrument>> FindAll()
    {
        try
        {
            return _Manager.FindAll();
        }
        catch
        {
            return NotFound();
        }

    }
    [HttpGet("id")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Instrument.Api.Instrument> FindById([FromHeader(Name = "id")] int id)
    {
        try
        {
            return _Manager.FindById(id);
        }
        catch
        {
            return NotFound();
        }

    }
}

