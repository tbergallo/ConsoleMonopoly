namespace ClassLibrary1
{
    public class Property
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Color { get; private set; }
        public int CostBuy { get; private set; }
        public int Owner { get; set; } // Settable since ownership may change
        public int NumberOfHouses { get; set; }

        public Property(string name, string type, string color, int costBuy, int owner = -1, int numberOfHouses = 0)
        {
            Name = name;
            Type = type;
            Color = color;
            CostBuy = costBuy;
            Owner = owner;
            NumberOfHouses = numberOfHouses;
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Position { get; set; }
        public int Money { get; set; }
        public Property[] Properties { get; set; }

        /*public Player(string name, int position, int money = 2000, Property[] properties)
        {
            Name = name;
            Position = position;
            Money = money;
            Properties = properties;
        }*/
    }
}