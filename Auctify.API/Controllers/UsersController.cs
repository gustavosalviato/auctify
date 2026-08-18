using Microsoft.AspNetCore.Mvc;

namespace Auctify.API.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}