using System.Collections.Generic;
using System.IO;
using System.Text;
using BigJoelSafari.Models;

namespace BigJoelSafari.Data
{
    public class AnimalDataImporter
    {
        private static bool IsDataLoaded = false;

        /**
         * Load and parse data from animal_data.csv
         */
        internal static void LoadData(AnimalData animalData)
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("Data/animal_data.csv"))
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

            /**
             * Parse each row array into a Animal object.
             * Assumes CSV column ordering: 
             *      name,employer,location,position type,core competency
             */
            foreach (string[] row in rows)
            {
                Size size = animalData.Sizes.AddUnique(row[1]);
                Origin origin = animalData.Origins.AddUnique(row[2]);
                Kind kind = animalData.Kinds.AddUnique(row[3]);
                Eat eat = animalData.Eats.AddUnique(row[4]);

                Animal newAnimal = new Animal
                {
                    Name = row[0],
                    Size = size,
                    Origin = origin,
                    Kind = kind,
                    Eat = eat,
                };
                animalData.Animals.Add(newAnimal);
            }

            IsDataLoaded = true;
        }


        /**
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