namespace BigJoelSafari.Models
{
    public class AnimalField
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Value { get; set; }

        public AnimalField()
        {
            ID = nextId;
            nextId++;
        }

        public AnimalField(string value) : this()
        {
            Value = value;
        }

        // Provide a basic case-insensitive search
        public bool Contains(string testValue)
        {
            return Value.ToLower().Contains(testValue.ToLower());
        }

        public override string ToString()
        {
            return Value;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (obj as AnimalField).ID == ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
