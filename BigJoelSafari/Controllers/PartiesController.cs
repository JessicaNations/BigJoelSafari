using Microsoft.AspNetCore.Mvc;


namespace BigJoelSafari.Controllers
{
    public class PartiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}