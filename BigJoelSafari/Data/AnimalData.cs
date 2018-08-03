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
        public AnimalFieldData<Size> Sizes { get; set; } = new AnimalFieldData<Size>();
        public AnimalFieldData<Origin> Origins { get; set; } = new AnimalFieldData<Origin>();
        public AnimalFieldData<Kind> Kinds { get; set; } = new AnimalFieldData<Kind>();
        public AnimalFieldData<Eat> Eats { get; set; } = new AnimalFieldData<Eat>();


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
                          where j.Size.Contains(value)
                          || j.Origin.Contains(value)
                          || j.Name.ToLower().Contains(value.ToLower())
                          || j.Eat.Contains(value)
                          || j.Kind.Contains(value)
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
                case AnimalFieldType.Size:
                    return animal.Size;
                case AnimalFieldType.Origin:
                    return animal.Origin;
                case AnimalFieldType.Eat:
                    return animal.Eat;
                case AnimalFieldType.Kind:
                    return animal.Kind;
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
