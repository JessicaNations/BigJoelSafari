using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BigJoelSafari.Models;

namespace BigJoelSafari.ViewModels
{
    public class SearchAnimalsViewModel : BaseViewModel
    {
        // TODO #7.1 - Extract members common to JobFieldsViewModel
        // to BaseViewModel

        // The search results
        public List<Animal> Animals { get; set; }

        // The column to search, defaults to all
        public AnimalFieldType Column { get; set; } = AnimalFieldType.All;

        // The search value
        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";
    }
}