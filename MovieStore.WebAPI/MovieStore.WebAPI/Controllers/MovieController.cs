using Microsoft.AspNetCore.Mvc;

namespace MovieStore.WebAPI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
