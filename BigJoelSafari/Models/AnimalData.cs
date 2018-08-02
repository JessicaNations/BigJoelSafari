using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BigJoelSafari.Models
{
    public class AnimalData
    {
        static List<Dictionary<string, string>> AllAnimals = new List<Dictionary<string, string>>();
        static bool IsDataLoaded = false;

        public static List<Dictionary<string, string>> FindAll()
        {
            LoadData();
            // Bonus mission: return a copy
            return new List<Dictionary<string, string>>(AllAnimals);
        }

        /*
         * Returns a list of all values contained in a given column,
         * without duplicates. 
         */
        public static List<string> FindAll(string column)
        {

            LoadData();

            List<string> values = new List<string>();

            foreach (Dictionary<string, string> animal in AllAnimals)
            {
                string aValue = animal[column];

                if (!values.Contains(aValue))
                {
                    values.Add(aValue);
                }
            }

            // Bonus mission: sort results alphabetically
                values.Sort();
            return values;
        }

        /**
         * Search all columns for the given term
         */
        public static List<Dictionary<string, string>> FindByValue(string value)
        {
            // load data, if not already loaded
            LoadData();

            List<Dictionary<string, string>> animals = new List<Dictionary<string, string>>();

            foreach (Dictionary<string, string> animal in AllAnimals)
            {
                foreach (string key in animal.Keys)
                {
                    if (animal[key].ToLower().Contains(value.ToLower()))
                    {
                        animals.Add(animal);
                    }
                }
            }

            return animals;
        }

        /**
         * Returns results of search the animals data by key/value, using
         * inclusion of the search term.
         *
         * For example, searching for employer "Enterprise" will include results
         * with "Enterprise Holdings, Inc".
         */
        public static List<Dictionary<string, string>> FindByColumnAndValue(string column, string value)
        {
            // load data, if not already loaded
            LoadData();

            List<Dictionary<string, string>> animals = new List<Dictionary<string, string>>();

            foreach (Dictionary<string, string> row in AllAnimals)
            {
                string aValue = row[column];

                if (aValue.ToLower().Contains(value.ToLower()))
                {
                    animals.Add(row);
                }
            }

            return animals;
        }

        /*
         * Load and parse data from animal_data.csv
         */
        private static void LoadData()
        {
            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("Models/animal_data.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArrray = CSVRowToStringArray(line);
                    if (rowArrray.Length > 0)
                    {
                        rows.Add(rowArrray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            // Parse each row array into a more friendly Dictionary
            foreach (string[] row in rows)
            {
                Dictionary<string, string> rowDict = new Dictionary<string, string>();

                for (int i = 0; i < headers.Length; i++)
                {
                    rowDict.Add(headers[i], row[i]);
                }
                AllAnimals.Add(rowDict);
            }

            IsDataLoaded = true;
        }

        /*
         * Parse a single line of a CSV file into a string array
         */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}