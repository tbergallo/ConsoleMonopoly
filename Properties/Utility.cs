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
        public int Owner { set; get; }
      
        public int CostBuy { get; set; }

        public Utility(string name, string type, int cost_buy = 150, int owner = -1) : base(name, type)
        {
            Owner = owner;
            CostBuy = cost_buy;
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
        public override void BuyProperty(Player player)
        {
            this.Owner = player.Player_number;
            player.Money -= this.CostBuy;
        }
        public override void PropertyAction(Player player, Player[] players)
        {
            base.PropertyAction(player, players);
        }
    }
}
