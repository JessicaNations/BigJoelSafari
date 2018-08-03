using Microsoft.AspNetCore.Mvc;
using BigJoelSafari.Models;
using BigJoelSafari.Data;
using BigJoelSafari.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace BigJoelSafari.Controllers
{
    public class ListController : Controller
    {
        // Our reference to the data store
        private static AnimalData animalData;

        static ListController()
        {
            animalData = AnimalData.GetInstance();
        }

        // Lists options for browsing, by "column"
        public IActionResult Index()
        {
            AnimalFieldsViewModel animalFieldsViewModel = new AnimalFieldsViewModel();
            animalFieldsViewModel.Title = "View Animal Fields";

            return View(animalFieldsViewModel);
        }

        // Lists the values of a given column, or all animals if selected
        public IActionResult Values(AnimalFieldType column)
        {
            if (column.Equals(AnimalFieldType.All))
            {
                SearchAnimalsViewModel animalsViewModel = new SearchAnimalsViewModel();
                animalsViewModel.Animals = animalData.Animals;
                animalsViewModel.Title = "All Animals";
                return View("Animals", animalsViewModel);
            }
            else
            {
                AnimalFieldsViewModel animalFieldsViewModel = new AnimalFieldsViewModel();

                IEnumerable<AnimalField> fields;

                switch (column)
                {
                    case AnimalFieldType.Employer:
                        fields = animalData.Employers.ToList().Cast<AnimalField>();
                        break;
                    case AnimalFieldType.Location:
                        fields = animalData.Locations.ToList().Cast<AnimalField>();
                        break;
                    case AnimalFieldType.CoreCompetency:
                        fields = animalData.CoreCompetencies.ToList().Cast<AnimalField>();
                        break;
                    case AnimalFieldType.PositionType:
                    default:
                        fields = animalData.PositionTypes.ToList().Cast<AnimalField>();
                        break;
                }

                animalFieldsViewModel.Fields = fields;
                animalFieldsViewModel.Title = "All " + column + " Values";
                animalFieldsViewModel.Column = column;

                return View(animalFieldsViewModel);
            }
        }

        // Lists Animals with a given field matching a given value
        public IActionResult Animals(AnimalFieldType column, string value)
        {
            SearchAnimalsViewModel animalsViewModel = new SearchAnimalsViewModel();
            animalsViewModel.Animals = animalData.FindByColumnAndValue(column, value);
            animalsViewModel.Title = "Animals with " + column + ": " + value;

            return View(animalsViewModel);
        }
    }
}