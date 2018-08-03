using System;
using System.Collections.Generic;
using BigJoelSafari.Models;

namespace BigJoelSafari.ViewModels
{
    public class AnimalFieldsViewModel : BaseViewModel
    {
        // TODO #7.2 - Extract members common to SearchAnimalsViewModel
        // to BaseViewModel

        // The current column
        public AnimalFieldType Column { get; set; }

        // All fields in the given column
        public IEnumerable<AnimalField> Fields { get; set; }
    }
}