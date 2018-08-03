namespace BigJoelSafari.Models
{
    public class Animal
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Size Size { get; set; }
        public Origin Origin { get; set; }
        public Eat Eat { get; set; }
        public Type Type { get; set; }

        public Animal()
        {
            ID = nextId;
            nextId++;
        }

    }
}
