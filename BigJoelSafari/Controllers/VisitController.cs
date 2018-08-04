using Microsoft.AspNetCore.Mvc;


namespace BigJoelSafari.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}