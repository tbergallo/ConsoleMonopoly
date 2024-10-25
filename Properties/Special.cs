using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Special : Property
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
        public override void PropertyAction(Player player, Player[] players)
        {
            base.PropertyAction(player, players);
        }
    }
}
