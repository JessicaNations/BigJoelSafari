using Microsoft.AspNetCore.Mvc;
using BigJoelSafari.Models;
using BigJoelSafari.Data;
using BigJoelSafari.ViewModels;

namespace BigJoelSafari.Controllers
{
    public class SearchController : Controller
    {
        // Our reference to the data store
        private static AnimalData animalData;

        static SearchController()
        {
            animalData = AnimalData.GetInstance();
        }

        // Display the search form
        public IActionResult Index()
        {
            SearchAnimalsViewModel animalsViewModel = new SearchAnimalsViewModel();
            animalsViewModel.Title = "Search";
            return View(animalsViewModel);
        }

        // Process search submission and display search results
        public IActionResult Results(SearchAnimalsViewModel animalsViewModel)
        {

            if (animalsViewModel.Column.Equals(AnimalFieldType.All) || animalsViewModel.Value.Equals(""))
            {
                animalsViewModel.Animals = animalData.FindByValue(animalsViewModel.Value);
            }
            else
            {
                animalsViewModel.Animals = animalData.FindByColumnAndValue(animalsViewModel.Column, animalsViewModel.Value);
            }

            animalsViewModel.Title = "Search";

            return View("Index", animalsViewModel);
        }
    }
}