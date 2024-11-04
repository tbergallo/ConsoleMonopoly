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
        public LuckCard[] CardDeck { get; set; }
        public int FortuneCounter { get; set; }
        public int ArkCounter { get; set; }

        public Luck(string name, string type, LuckCard[] cardDeck) : base(name, type)
        {
            CardDeck = cardDeck;
            FortuneCounter = 0;
            ArkCounter = 0;
        }
        
        public override void PropertyAction(Player player, Player[] players)
        {
            CardDeck[FortuneCounter].CauseEffect(player);
            FortuneCounter++;
        }
    }
    internal class LuckCard
    {
        public string LuckType { get; set; }
        public int ReferenceNumber { get; set; }
        public string Message { get; set; }
        public LuckCard(string luckType, int referenceNumber, string message)
        {
            LuckType = luckType;
            ReferenceNumber = referenceNumber;
            Message = message;
        }
        public LuckCard[] InitializeChanceDeck()
        {
            LuckCard[] chanceDeck =
            {
                new LuckCard("Displacement", 0, "Advance to Go (Collect $200)"), // GO
                new LuckCard("Displacement", 24, "Advance to Illinois Ave - If you pass Go, collect $200"), // Illinois Avenue (3rd in the property array)
                new LuckCard("Displacement", 11, "Advance to St. Charles Place - If you pass Go, collect $200"), // St. Charles Place (11th in the property array)
                /*See how to check nearest ut*/new LuckCard("Displacement", 6, "Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner ten times the amount thrown."), // Electric Company (6th in the property array)
                /*See how to check nearest ut*/new LuckCard("Displacement", 5, "Advance token to the nearest Railroad and pay owner twice the rental to which they are otherwise entitled. If Railroad is unowned, you may buy it from the Bank."), // Reading Railroad (5th in the property array)
                new LuckCard("Money", 50, "Bank pays you dividend of $50"),
                new LuckCard("Other", 0, "Get Out of Jail Free"),
                new LuckCard("Movement", -3, "Go Back 3 Spaces"), // Move back 3 spaces
                new LuckCard("Displacement", 10, "Go directly to Jail. Do not pass Go, do not collect $200"),
                /*See how to calculate*/new LuckCard("Money", 25, "Make general repairs on all your property - For each house pay $25, For each hotel pay $100"),
                new LuckCard("Money", 15, "Pay poor tax of $15"),
                new LuckCard("Displacement", 5, "Take a trip to Reading Railroad - If you pass Go, collect $200"), // Reading Railroad (6th in the property array)
                new LuckCard("Displacement", 39, "Take a walk on the Boardwalk - Advance token to Boardwalk"), // Boardwalk (39th in the property array)
                /*See how to calculate*/new LuckCard("Money", 50, "You have been elected Chairman of the Board - Pay each player $50"),
                new LuckCard("Money", 150, "Your building loan matures - Collect $150"),
                new LuckCard("Money", 100, "You have won a crossword competition - Collect $100")
            };
            return chanceDeck;
        }
        public void InitializeCommunityChestDeck()
        {

        }
        public void CauseEffect(Player player)
        {
            switch (LuckType)
            {
                case "Movement":
                    player.Position -= ReferenceNumber;
                    break;
                case "Displacemente":
                    player.Position = ReferenceNumber;
                    // Think how to include payment multipliers
                    break;
                case "Money":
                    player.Money += ReferenceNumber;
                    break;
            }
        }
    }
}
