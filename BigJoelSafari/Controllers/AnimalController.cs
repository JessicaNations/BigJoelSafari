using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using BigJoelSafari.Data;
using BigJoelSafari.Models;
using BigJoelSafari.ViewModels;

namespace BigJoelSafari.Controllers
{
    public class AnimalController : Controller
    {

        // Our reference to the data store
        private static AnimalData animalData;

        static AnimalController()
        {
            animalData = AnimalData.GetInstance();
        }

        // The detail display for a given Animal at URLs like /Animal?id=17
        public IActionResult Index(int id)
        {
            //TODO #1 - get the Animal with the given ID and pass it into the view

            Animal theAnimal = animalData.Find(id);
            NewAnimalViewModel theRealAnimal = new NewAnimalViewModel();

            theRealAnimal.Name = theAnimal.Name;
            theRealAnimal.SizeID = theAnimal.Size.ID;
            theRealAnimal.EatID = theAnimal.Eat.ID;
            theRealAnimal.OriginID = theAnimal.Origin.ID;
            theRealAnimal.TypeID = theAnimal.Type.ID;

            return View(theAnimal);
        }

        public IActionResult New()
        {
            NewAnimalViewModel newAnimalViewModel = new NewAnimalViewModel();
            return View(newAnimalViewModel);
        }

        [HttpPost]
        public IActionResult New(NewAnimalViewModel newAnimalViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Animal and add it to the AnimalData data store. Then
            // redirect to the Animal detail (Index) action/view for the new Animal


            if (ModelState.IsValid)
            {
                Animal newAnimal = new Animal
                {
                    Name = newAnimalViewModel.Name,
                    Size = animalData.Sizes.Find(newAnimalViewModel.SizeID),
                    Origin = animalData.Origins.Find(newAnimalViewModel.OriginID),
                    Eat = animalData.Eats.Find(newAnimalViewModel.EatID),
                    Type = animalData.Types.Find(newAnimalViewModel.TypeID)
                };

                animalData.Animals.Add(newAnimal);
                return Redirect(String.Format("/animal?id={0}", newAnimal.ID));
            }

            //AnimalData data = AnimalData.GetInstance();
            //Animal newAnimal = new Animal();
            //newAnimal.Employer = data.Employers.Find(newAnimalViewModel.EmployerID.ID);

            return View(newAnimalViewModel);
        }
    }
}
    {
    }
}
