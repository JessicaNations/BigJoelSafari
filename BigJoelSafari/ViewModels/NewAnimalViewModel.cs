using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BigJoelSafari.Data;
using BigJoelSafari.Models;

namespace BigJoelSafari.ViewModels
{
    public class NewAnimalViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Size")]
        public int SizeID { get; set; }

        [Required]
        [Display(Name = "Origin")]
        public int OriginID { get; set; }

        [Required]
        [Display(Name = "Kind")]
        public int KindID { get; set; }

        [Required]
        [Display(Name = "Eat")]
        public int EatID { get; set; }

        // TODO #3 - Included other fields needed to create a animal,
        // with correct validation attributes and display names.

        public List<SelectListItem> Sizes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Origins { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Eats { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Kinds { get; set; } = new List<SelectListItem>();

        public NewAnimalViewModel()
        {

            AnimalData animalData = AnimalData.GetInstance();

            foreach (Size field in animalData.Sizes.ToList())
            {
                Sizes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (Origin field in animalData.Origins.ToList())
            {
                Origins.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (Kind field in animalData.Kinds.ToList())
            {
                Kinds.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (Eat field in animalData.Eats.ToList())
            {
                Eats.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

        }
    }
}