using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BigJoelSafari.Models;

namespace BigJoelSafari.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.columns = ListController.columnChoices;

            if (searchType == "all")
            {
                List<Dictionary<string, string>> allAnimals = AnimalData.FindByValue(searchTerm);
                ViewBag.animals = allAnimals;
            }

            else
            {
                List<Dictionary<string, string>> allAnimals = AnimalData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.animals = allAnimals;
            }

            return View("Index");
        }
    }
}