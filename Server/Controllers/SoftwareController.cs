using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("api/software")]
public class SoftwareController : ControllerBase
{
    [HttpGet("Create")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Create([FromRoute(Name = "Name")] string name, [FromRoute(Name = "Price")] double price)
    {
        return Ok("OK");
        //return _storeService.GetStock(category, item).ToString();
    }
}
