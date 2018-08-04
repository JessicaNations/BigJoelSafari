using Microsoft.AspNetCore.Mvc;


namespace BigJoelSafari.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}