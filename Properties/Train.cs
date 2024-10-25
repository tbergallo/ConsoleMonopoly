using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Train : Property
    {
        public int Owner { get; set; }
        public int CostBuy { get; set; }
        public int[] MustPay { get; set; }


        public Train(string name, string type, int costBuy = 200, int owner = -1) : base(name, type)
        {
            Owner = owner;
            CostBuy = costBuy;
            MustPay = [25, 50, 100, 200];
        }

        public int TotalRent(Player owner)
        {
            int ticket = MustPay[owner.NumberOfTrainsOwned-1];
            return ticket;
        }
        /*public override void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
        }*/
        public void RentPayment(Player owner, Player renter)
        {
            int rent = this.TotalRent(owner);
            renter.Money -= rent;
            owner.Money += rent;
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
                Player owner = players[this.Owner - 1];
                Console.WriteLine($"The property is owned by player {this.Owner}");
                Console.WriteLine($"You must pay him {this.TotalRent(owner)}");
                this.RentPayment(players[this.Owner - 1], player);
                Console.WriteLine($"The owner, {players[this.Owner - 1].Player_number} now has {players[this.Owner - 1].Money}");
            }
        }

    }
}
