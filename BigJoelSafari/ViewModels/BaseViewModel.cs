using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigJoelSafari.Models;

namespace BigJoelSafari.ViewModels
{
    public class BaseViewModel
    {
        // All columns, for display
        public List<AnimalFieldType> Columns { get; set; }

        // View title
        public string Title { get; set; } = "";

        public BaseViewModel()
        {
            // Populate the list of all columns

            Columns = new List<AnimalFieldType>();

            foreach (AnimalFieldType enumVal in Enum.GetValues(typeof(AnimalFieldType)))
            {
                Columns.Add(enumVal);
            }
        }
    }
}