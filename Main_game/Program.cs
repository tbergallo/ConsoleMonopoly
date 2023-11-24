/*
string player_name = "Juan";
int player_money = 2000;
string player_position = "Disco de Stu";
string player_properties = "Rancho relaxo";
int player_move;

Console.WriteLine("It's your turn " + player_name + "!" +
    "\nYour are standing on " + player_position +
    "\nYour money: $" + player_money +
    "\nYour properties: " + player_properties +
    "\nWhat do you want to do? \n1) Roll dice\n2) Negociate");

player_move = Convert.ToInt32(Console.ReadLine()) ;


if (player_move == 1)
{
    Console.WriteLine("A 6!");
    //rolldice()
}
else if (player_move == 2)
{
    Console.WriteLine("Who do you want to negociate with?");
    //negociate()
}
*/

namespace MainGame
{
    public class Property
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Property(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public virtual void Display_Details()
        {
            Console.WriteLine($"Name: {Name}\nType: {Type}");
        }
    }
    public class Street : Property
    {
        public string Color { get; private set; }
        public int CostBuy { get; private set; }
        public int Owner { get; set; }
        public int NumberOfHouses { get; set; }
        public int[] MustPay { get; set; }

        public Street(string name, string type, string color, int costBuy, int[] must_pay, int owner = -1, int numberOfHouses = 0) 
            : base(name , type)
        {
            Color = color;
            CostBuy = costBuy;
            Owner = owner;
            NumberOfHouses = numberOfHouses;
            MustPay = must_pay;
        }

        public void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
        }

        public int Payment()
        {
            int rent = this.MustPay[this.NumberOfHouses];
            return rent;
        }

        // BuyProperty
        // ExchangeProperty
        // BuyHouse
        // SellHouse
    }
    public class Train : Property
    {
        public int Owner { get; set; }
        public int CostBuy { get; set; }
        public int MustPay { get; set; }


        public Train(string name, string type, int costBuy = 200, int owner = -1, int mustPay = 25) : base(name, type)
        {
        }

        public int Payment(int mustPay, int NumberOfTrains)
        {
            int ticket = mustPay * NumberOfTrains;
            return ticket;
        }
        public void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
        }

        // ExchangeProperty

    }
    public class Utility : Property
    {
        public int Owner { set; get; }
        //public int Owner2 { set; get; }
        public int CostBuy { get; set; }

        //public int PaymentMultiplier { set; get; }

        public Utility(string name, string type, int cost_buy = 150, int owner = -1 /*int owner2 = -1*/) : base(name, type)
        {
        }
        
        public int CalculatePayment(int dice, int utilitiesOwned)
        {
            if (utilitiesOwned == 1)
            {
                return dice * 4;
            }
            else
            {
                return dice * 10;
            }
        }
        public void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
        }
        // Set multiplier to 10 if two owned by 1 playere
        // BuyProperty
        // ExchangeProperty

    }
    public class Special : Property
    {
        public int Amount { get; set; }
        public int Effect { get; set; }

        public Special(string name, string type, int amount, int effect) : base(name, type)
        {
            Amount = amount;
            Effect = effect;
        }

        public int CauseEffect(int amount, int effect)
        {
            int effection = amount * effect;
            return effection;
        }
    }
    public class Luck : Property
    {
        public string Type { get; set; }
        public int ReferenceNumber { get; set; }
        public string Message { get; set; }
        public Luck(string name, string type, string type_luck,  int referenceNumber, string message) : base(name, type)
        {
            Type = type_luck;
            ReferenceNumber = referenceNumber;
            Message = message;
        }
        public void CauseEffect(Player player, string type, int referenceNumber, int paymentMultiplier)
        {
            switch (type)
            {
                case "Movement":
                    player.Position -= referenceNumber;
                    break;
                case "Displacemente":
                    player.Position = referenceNumber;
                    // Think how to include payment multipliers
                    break;
                case "Money":
                    player.Money += player.Money;
                    break;

            }
        }
    }
    // public class Jail : Property
    public class Player
    {
        public string Name { get; private set; }
        public int Player_number { get; set; }
        public int Position { get; set; }
        public int Money { get; set; }
        public int[] Properties { get; set; }
        public int last_dice_roll { get; set; }
        public int NumberOfTrainsOwned { get; set; }
        public int NumberOfUtilitiesOwned { get; set; }

        public Player(string name, int player_number = -1, int position = 0, int money = 2000, int[] properties = null, int last_dice_roll = -1)
        {
            Name = name;
            Player_number = player_number;
            Position = position;
            Money = money;
            Properties = properties ?? new int[36];
            NumberOfTrainsOwned = 0;
            NumberOfUtilitiesOwned = 0;
        }
    }
    public class Game
    {
        public Player[] StartingGame(int num_players)
        {
            Player[] players = new Player[num_players];

            for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine($"What is the name of player # {i + 1}");
                string player_name = Console.ReadLine();
                players[i] = new Player(player_name);
            }

            foreach (var player in players)
            {
                Console.WriteLine($"Welcome {player.Name}!");
            }

            Console.WriteLine($"Let's roll the dice to see who starts");

            Random random = new Random();
            int highest_dice = 0;
            int index_first_player = 0;

            for (int i = 0; i < num_players; i++)
            {

                int dice_roll = random.Next(1, 7);
                Console.WriteLine($"{players[i].Name} rolled a {dice_roll}!");
                players[i].last_dice_roll = dice_roll;
                Console.ReadLine();

                if (dice_roll > highest_dice)
                {
                    highest_dice = dice_roll;
                    index_first_player = i;
                }
                // What happens if two or more roll the same dice?
            }

            Player[] ordered_players = players.OrderByDescending(player => player.last_dice_roll).ToArray();
            
            for (int i = 0; i < ordered_players.Length; i++)
            {
                ordered_players[i].Player_number = i + 1;
            }
            
            return ordered_players;
        }
        public Property[] InizializeBoard()
        {
            Property[] board = new Property[]
        {
            new Special("GO", "Special", 200, 1),
            new Street("Mediterranean Avenue", "Street", "Brown", 60, new int[] {25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Baltic Avenue", "Street", "Brown", 60, new int[] {25, 75, 100, 125, 150 }),
            new Special("Income Tax", "Tax", -200, 2),
            new Train("Reading Railroad", "Train"),
            new Street("Oriental Avenue", "Street", "Light Blue", 100, new int[] {25, 75, 100, 125, 150 }),
            new Special("Chance", "Special", 0, 0),
            new Street("Vermont Avenue", "Street", "Light Blue", 100, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Connecticut Avenue", "Street", "Light Blue", 120, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Jail", "Special", 0, 0),
            new Street("St. Charles Place", "Street", "Pink", 140, new int[] { 25, 75, 100, 125, 150 }),
            new Utility("Electric Company", "Utility"),
            new Street("States Avenue", "Street", "Pink", 140, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Virginia Avenue", "Street", "Pink", 160, new int[] { 25, 75, 100, 125, 150 }),
            new Train("Pennsylvania Railroad", "Train"),
            new Street("St. James Place", "Street", "Orange", 180, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Tennessee Avenue", "Street", "Orange", 180, new int[] { 25, 75, 100, 125, 150 }),
            new Street("New York Avenue", "Street", "Orange", 200, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Free Parking", "Special", 0, 0),
            new Street("Kentucky Avenue", "Street", "Red", 220, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Chance", "Special", 0, 0),
            new Street("Indiana Avenue", "Street", "Red", 220, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Illinois Avenue", "Street", "Red", 240, new int[] { 25, 75, 100, 125, 150 }),
            new Train("B. & O. Railroad", "Train"),
            new Street("Atlantic Avenue", "Street", "Yellow", 260, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Ventnor Avenue", "Street", "Yellow", 260, new int[] { 25, 75, 100, 125, 150 }),
            new Utility("Water Works", "Utility"),
            new Street("Marvin Gardens", "Street", "Yellow", 280, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Go to Jail", "Special", 0, 0),
            new Street("Pacific Avenue", "Street", "Green", 300, new int[] { 25, 75, 100, 125, 150 }),
            new Street("North Carolina Avenue", "Street", "Green", 300, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Pennsylvania Avenue", "Street", "Green", 320, new int[] { 25, 75, 100, 125, 150 }),
            new Train("Short Line", "Train"),
            new Special("Chance", "Special", 0, 0),
            new Street("Park Place", "Street", "Dark Blue", 350, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Luxury Tax", "Tax", -100, 3),
            new Street("Boardwalk", "Street", "Dark Blue", 400, new int[] { 25, 75, 100, 125, 150 }),
        };
            return board;
        }
        public int rollDice()
        {
            Random random = new Random();
            int roll_dice_1 = random.Next(1, 7);
            int roll_dice_2 = random.Next(1, 7);
            return roll_dice_1 + roll_dice_2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameMonopoly();
        }
        
        static void GameMonopoly()
        {

            Game game = new Game();

            Property[] board = game.InizializeBoard();

            Console.WriteLine("Welcome! How many players will be playing? (Choose 2 to 6)");

            int num_players = Convert.ToInt32(Console.ReadLine());

            Player[] players = game.StartingGame(num_players);

            int i = 0;

            while (i < 10)
            {
                Player current_player = players[i];
                // Player header method
                Console.WriteLine($"{current_player.Name}, it's your turn!" +
                                $"\nYour are standing on {board[current_player.Position].Name}" +
                                $"\nYour money: ${current_player.Money}" +
                                $"\nWhat do you want to do? \n1) Roll dice");

                // Build houses, consult unsold properties, consult your others' properties
                // What happens when you don't have money to pay

                int player_choice = Convert.ToInt32(Console.ReadLine());
                // End player header method
                if (player_choice == 1)
                {
                    // Movement method
                    int dice_roll = game.rollDice();
                    Console.WriteLine($"You rolled a {dice_roll}!");
                    current_player.Position = dice_roll + current_player.Position;
                    
                    if (current_player.Position >= 36)
                    {
                        current_player.Position -= 36;
                    }
                    int current_position = current_player.Position;
                    Console.WriteLine($"You are now standing on {board[current_position].Name}");
                    // End movement method

                    switch (board[current_position].Type)
                    {
                        case "Street":
                            Street current_street = (Street)board[current_position];
                            if (current_street.Owner == -1)
                            {
                                Console.WriteLine("No one owns this property. Would you like to buy it? 1) Yes 2) No");
                                player_choice = Convert.ToInt32(Console.ReadLine());
                                if (player_choice == 1)
                                {
                                    current_street.BuyProperty(current_player);
                                    Console.WriteLine($"You now own {current_street.Name}!");
                                }
                                else
                                {
                                    break;
                                }
                                // Create exception when the player does not have enough money
                            }
                            else if (current_street.Owner == current_player.Player_number)
                            {
                                Console.WriteLine("The property is yours!");
                            }
                            else
                            {
                                Console.WriteLine($"The property is owned by player {players[(current_street.Owner - 1)].Name}");
                                // If he owns houses, mention it
                                Console.WriteLine($"You pay him ${current_street.Payment()}");
                                current_player.Money -= current_street.Payment();
                            }
                            break;
                    }
                    i++;
                    if (i >= players.Length)
                    {
                        i = 0;
                    }

                }

            }
        }
    }
}
