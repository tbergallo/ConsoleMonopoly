using ConsoleMonopolyAutomate.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopolyAutomate.Properties
{
    internal class Luck : Property
    {
        public string LuckType { get; set; }
        public int ReferenceNumber { get; set; }
        public string Message { get; set; }
        public Luck(string name, string type, string luckType, int referenceNumber, string message) : base(name, type)
        {
            LuckType = luckType;
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
        public override void PropertyAction(Player player, Player[] players)
        {
            base.PropertyAction(player, players);
        }
    }
}
