using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BigJoelSafari.Models;

namespace BigJoelSafari.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController()
        {

            columnChoices.Add("Food Type", "Food Type");
            columnChoices.Add("Size", "Size");
            columnChoices.Add("Origin", "Origin");
            columnChoices.Add("Type", "Type");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()
        {
            ViewBag.columns = columnChoices;
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("all"))
            {
                List<Dictionary<string, string>> animals = AnimalData.FindAll();
                ViewBag.title = "All Animals";
                ViewBag.animals = animals;
                return View("Animals");
            }
            else
            {
                List<string> items = AnimalData.FindAll(column);
                ViewBag.title = "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Animals(string column, string value)
        {
            List<Dictionary<String, String>> animals = AnimalData.FindByColumnAndValue(column, value);
            ViewBag.title = "Animals with " + columnChoices[column] + ": " + value;
            ViewBag.animals = animals;

            return View();
        }
    }
}