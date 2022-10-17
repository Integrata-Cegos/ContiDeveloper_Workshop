using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;
public class SoftwareController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
