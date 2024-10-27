using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMonopolyAutomate.Players;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Utility : Property
    {
        public override int Owner { set; get; }
      
        public override int CostBuy { get; set; }

        public Utility(string name, string type, int cost_buy = 150, int owner = -1) : base(name, type)
        {
            Owner = owner;
            CostBuy = cost_buy;
        }

        public int TtotalUtilityPayment(Player player)
        {
            int diceRoll = player.last_dice_roll;
            if (player.NumberOfUtilitiesOwned == 1)
            {
                return diceRoll * 4;
            }
            else
            {
                return diceRoll * 10;
            }
        }
        public void RentPayment(Player owner, Player renter)
        {
            int rent = this.TtotalUtilityPayment(owner);
            renter.Money -= rent;
            owner.Money += rent;
        }
        public override void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
            player.NumberOfUtilitiesOwned++;
        }
        public override void PropertyAction(Player player, Player[] players)
        {
            if (this.Owner == -1)
            {
                //Eventualmente, agregar tomador de decision si compra o no.
                if (player.Money >= this.CostBuy)
                {
                    Console.WriteLine($"Nobody owns {this.Name} so you buy it for ${this.CostBuy}");
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
                Console.WriteLine($"You must pay him ${this.TtotalUtilityPayment(owner)}");
                this.RentPayment(players[this.Owner - 1], player);
                Console.WriteLine($"The owner, {players[this.Owner - 1].Player_number} now has {players[this.Owner - 1].Money}");
            }
        }
    }
}
