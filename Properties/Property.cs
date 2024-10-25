using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Property
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Value { get; private set; }
        public bool Morgaged { get; private set; }
        public int Owner { get; private set; }
        public int CostBuy { get; private set; }

        public Property(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public virtual void Display_Details()
        {
            Console.WriteLine($"Name: {Name}\nType: {Type}");
        }

        public virtual void PropertyAction(Player player, Player[] players){}

        public override string ToString()
        {
            return $"{Name}";
        }
        public void AllSold(Property[] board)
        {
            bool allsold = true;
            foreach (var property in board)
            {
                if(property.Type == "Street" && property.Owner == -1)
                {
                    allsold = false;
                }
            }
            if (allsold)
            {
                Console.WriteLine("All streets have been sold.");
                Environment.Exit(0);
            }
        }
        public virtual void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
            player.Properties.Add(this);
        }
    }
}
