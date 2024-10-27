using ConsoleMonopolyAutomate.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleMonopolyAutomate.Players
{
    internal class Player
    {
        public int Player_number { get; set; }
        public int ThroughGo { get; set; }

        private int position;
        public int Position
        {
            get => position;
            set
            {
                if (value >= 36)
                {
                    Money += 200;
                    Console.WriteLine($"Player {Player_number} passed through GO and received $200.");
                    this.ThroughGo += 1;
                }
                position = value % 36;
            }
        }
        public int Money { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public int last_dice_roll { get; set; }
        public int NumberOfTrainsOwned { get; set; }
        public int NumberOfUtilitiesOwned { get; set; }

        public Player(int player_number = -1, int position = 0, int money = 2000, List<Property> properties = null, int last_dice_roll = -1)
        {
            Player_number = player_number;
            Position = position;
            Money = money;
            Properties = properties ?? new List<Property>();
            NumberOfTrainsOwned = 0;
            NumberOfUtilitiesOwned = 0;
        }
    }
}
