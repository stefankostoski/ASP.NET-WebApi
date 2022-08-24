using Microsoft.AspNetCore.Mvc;

namespace MovieApp.API.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return Unauthorized();
        }
    }
}
