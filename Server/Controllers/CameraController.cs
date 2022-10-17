using Camera.Impl;
using Camera.Api;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Camera.Controller;

[ApiController]
[Route("[controller]")]
public class CameraController : ControllerBase
{
    private readonly Camera.Impl.CameraManager _cameraManager;

    public CameraController(Camera.Impl.CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<int> Create([FromHeader(Name="Name")] string name, [FromHeader(Name="Price")] double price)
    {
        try
        {
            return _cameraManager.Create(name, price);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }

    [HttpGet("id")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Camera.Api.Camera> FindById([FromHeader(Name="Id")] int id)
    {
        try
        {
            return _cameraManager.FindById(id);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet("all")]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Camera.Api.Camera>> FindAll()
    {
        try
        {
            return _cameraManager.FindAll();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult Update([FromBody] Camera.Api.Camera camera)
    {
        try
        {
            return _cameraManager.Update(camera);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }

    [HttpDelete]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult Delete([FromHeader(Name="Id")] int id)
    {
        try
        {
            return _cameraManager.DeleteById(id);
        }
        catch
        {
            return UnprocessableEntity();
        }
    }
}