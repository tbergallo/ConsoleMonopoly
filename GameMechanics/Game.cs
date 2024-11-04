using ConsoleMonopolyAutomate.Properties;
using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.GameMechanics
{
    internal class Game
    {
        public int NumberOfPlayers { get; set; }
        public int NumberOfRounds { get; set; }
        public Player[] Players { get; set; }

        public void SetGameProperties()
        {
            //Console.WriteLine("Set number of players");
            //this.NumberOfPlayers = Convert.ToInt32(Console.ReadLine());
            this.NumberOfPlayers = 3;
            this.NumberOfRounds = 100;

        }
        public void StartingGame()
        {
            Player[] players = new Player[this.NumberOfPlayers];

            /*for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine($"What is the name of player # {i + 1}");
                string player_name = Console.ReadLine();
                players[i] = new Player(player_name);
            }

            foreach (var player in players)
            {
                Console.WriteLine($"Welcome {player.Name}!");
            }*/

            Console.WriteLine($"Let's roll the dice to see who starts");

            Random random = new Random();
            int highest_dice = 0;
            int index_first_player = 0;

            for (int i = 0; i < this.NumberOfPlayers; i++)
            {
                players[i] = new Player();
                int dice_roll = random.Next(1, 7);
                Console.WriteLine($"{i} rolled a {dice_roll}!");
                players[i].last_dice_roll = dice_roll;

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
            Console.WriteLine($"{ordered_players[0].Player_number} starts!");
            Console.WriteLine("");
            this.Players = ordered_players;
        }
        public Property[] InizializeBoard()
        {
            Property[] board = new Property[]
        {
            new Special("GO", "Special", 200, 1),
            new Street("Mediterranean Avenue", "Street", "Brown", 60, 50, new int[] {25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Baltic Avenue", "Street", "Brown", 60, 50, new int[] {25, 75, 100, 125, 150 }),
            new Special("Income Tax", "Tax", -200, 2),
            new Train("Reading Railroad", "Train"),
            new Street("Oriental Avenue", "Street", "Light Blue", 100, 50, new int[] {25, 75, 100, 125, 150 }),
            new Special("Chance", "Special", 0, 0),
            new Street("Vermont Avenue", "Street", "Light Blue", 100, 50, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Connecticut Avenue", "Street", "Light Blue", 120, 50, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Jail", "Special", 0, 0),
            new Street("St. Charles Place", "Street", "Pink", 140, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Utility("Electric Company", "Utility"),
            new Street("States Avenue", "Street", "Pink", 140, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Virginia Avenue", "Street", "Pink", 160, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Train("Pennsylvania Railroad", "Train"),
            new Street("St. James Place", "Street", "Orange", 180, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Tennessee Avenue", "Street", "Orange", 180, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Street("New York Avenue", "Street", "Orange", 200, 100, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Free Parking", "Special", 0, 0),
            new Street("Kentucky Avenue", "Street", "Red", 220, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Chance", "Special", 0, 0),
            new Street("Indiana Avenue", "Street", "Red", 220, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Illinois Avenue", "Street", "Red", 240, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Train("B. & O. Railroad", "Train"),
            new Street("Atlantic Avenue", "Street", "Yellow", 260, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Street("Ventnor Avenue", "Street", "Yellow", 260, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Utility("Water Works", "Utility"),
            new Street("Marvin Gardens", "Street", "Yellow", 280, 150, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Go to Jail", "Special", 0, 0),
            new Street("Pacific Avenue", "Street", "Green", 300, 200, new int[] { 25, 75, 100, 125, 150 }),
            new Street("North Carolina Avenue", "Street", "Green", 300, 200, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Community Chest", "Special", 0, 0),
            new Street("Pennsylvania Avenue", "Street", "Green", 320, 200, new int[] { 25, 75, 100, 125, 150 }),
            new Train("Short Line", "Train"),
            new Special("Chance", "Special", 0, 0),
            new Street("Park Place", "Street", "Dark Blue", 350, 200, new int[] { 25, 75, 100, 125, 150 }),
            new Special("Luxury Tax", "Tax", -100, 3),
            new Street("Boardwalk", "Street", "Dark Blue", 400, 200, new int[] { 25, 75, 100, 125, 150 }),
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
        public void PrintStats(Player[] players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Player {player.Player_number} ended with ${player.Money}.");
                Console.WriteLine($"It went through Go {player.ThroughGo} times.");
                Console.WriteLine($"He owns {player.Properties.Count} properties.");
                Console.WriteLine("The properties are: " + string.Join(", ", player.Properties));
            }
        }
        public void CheckAllPropertiesSold(Property[] board)
        {
            bool allSold = board
                .Where(p => p is Street || p is Train || p is Utility) // Select relevant property types
                .All(p => p.Owner != -1);  // Ensure all have owners

            if (allSold)
            {
                Console.WriteLine("All properties have been sold. Terminating the game.");
                Environment.Exit(0);  // Stop the program
            }
        }
        public void PrintUnsoldProperties(Property[] board)
        {
            var unsoldProperties = board
                .Where(p => p.Owner == -1) // Filter properties that are unsold
                .ToList();  // Convert to a list for easy display

            if (unsoldProperties.Count == 0)
            {
                Console.WriteLine("All properties have been sold!");
            }
            else
            {
                Console.WriteLine("The following properties are still unsold:");
                foreach (var property in unsoldProperties)
                {
                    Console.WriteLine($"- {property.Name} ({property.Type})");
                }
            }
        }

    }
}
