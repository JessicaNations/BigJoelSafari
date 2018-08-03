using System;
using System.Collections.Generic;
using System.Linq;
using BigJoelSafari.Models;

namespace BigJoelSafari.Data
{
    class AnimalData
    {
        /**
         * A data store for Animal objects
         */

        public List<Animal> Animals { get; set; } = new List<Animal>();
        public AnimalFieldData<Employer> Employers { get; set; } = new AnimalFieldData<Employer>();
        public AnimalFieldData<Location> Locations { get; set; } = new AnimalFieldData<Location>();
        public AnimalFieldData<PositionType> PositionTypes { get; set; } = new AnimalFieldData<PositionType>();
        public AnimalFieldData<CoreCompetency> CoreCompetencies { get; set; } = new AnimalFieldData<CoreCompetency>();


        private AnimalData()
        {
            AnimalDataImporter.LoadData(this);
        }

        private static AnimalData instance;
        public static AnimalData GetInstance()
        {
            if (instance == null)
            {
                instance = new AnimalData();
            }

            return instance;
        }


        /**
         * Return all Animal objects in the data store
         * with a field containing the given term
         */
        public List<Animal> FindByValue(string value)
        {
            var results = from j in Animals
                          where j.Employer.Contains(value)
                          || j.Location.Contains(value)
                          || j.Name.ToLower().Contains(value.ToLower())
                          || j.CoreCompetency.Contains(value)
                          || j.PositionType.Contains(value)
                          select j;

            return results.ToList();
        }


        /**
         * Returns results of search the animals data by key/value, using
         * inclusion of the search term.
         */
        public List<Animal> FindByColumnAndValue(AnimalFieldType column, string value)
        {
            var results = from j in Animals
                          where GetFieldByType(j, column).Contains(value)
                          select j;

            return results.ToList();
        }

        /**
         * Returns the AnimalField of the given type from the Animal object,
         * for all types other than AnimalFieldType.All. In this case, 
         * null is returned.
         */
        public static AnimalField GetFieldByType(Animal animal, AnimalFieldType type)
        {
            switch (type)
            {
                case AnimalFieldType.Employer:
                    return animal.Employer;
                case AnimalFieldType.Location:
                    return animal.Location;
                case AnimalFieldType.CoreCompetency:
                    return animal.CoreCompetency;
                case AnimalFieldType.PositionType:
                    return animal.PositionType;
            }

            throw new ArgumentException("Cannot get field of type: " + type);
        }


        /**
         * Returns the Animal with the given ID,
         * if it exists in the store
         */
        public Animal Find(int id)
        {
            var results = from j in Animals
                          where j.ID == id
                          select j;

            return results.Single();
        }

    }
}
