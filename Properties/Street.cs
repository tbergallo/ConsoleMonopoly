using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Street : Property
    {
        public string Color { get; private set; }
        public int CostBuy { get; private set; }
        public int HouseCost { get; private set; }
        public int Owner { get; set; }
        public int NumberOfHouses { get; set; }
        public int[] Rent { get; set; }

        public Street(string name, string type, string color, int costBuy, int houseCost, int[] rent, int owner = -1, int numberOfHouses = 0)
            : base(name, type)
        {
            Color = color;
            CostBuy = costBuy;
            HouseCost = houseCost;
            Owner = owner;
            NumberOfHouses = numberOfHouses;
            Rent = rent;
        }

        /*public void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
            player.Properties.Add(this);
        }*/

        public int TotalRent()
        {
            int rent = this.Rent[this.NumberOfHouses];
            return rent;
        }
        public void RentPayment(Player owner, Player renter)
        {
            int rent = this.TotalRent();
            renter.Money -= rent;
            owner.Money += rent;
        }

        public void BuildHouse()
        {
            this.NumberOfHouses++;
        }

        public override void PropertyAction(Player player, Player[] players)
        {
            if (this.Owner == -1)
            {
                //Eventualmente, agregar tomador de decision si compra o no.
                if (player.Money >= this.CostBuy)
                {
                    Console.WriteLine($"Nobody owns {this.Name} so you buy it for {this.CostBuy}");
                    this.BuyProperty(player);
                    Console.WriteLine($"You now have ${player.Money}");
                }
                else
                {
                    Console.WriteLine("You do not have enough money to buy it.");
                }
            }
            else if (this.Owner == player.Player_number)
            {
                Console.WriteLine("The property is yours!");
            }
            else
            {
                Console.WriteLine($"The property is owned by player {this.Owner}");
                Console.WriteLine($"You must pay him {this.TotalRent()}");
                this.RentPayment(players[this.Owner - 1], player);
                Console.WriteLine($"The owner, {players[this.Owner - 1].Player_number} now has {players[this.Owner - 1].Money}");
            }
        }
    }
}
