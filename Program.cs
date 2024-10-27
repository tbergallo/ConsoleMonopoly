using ConsoleMonopolyAutomate.GameMechanics;
using ConsoleMonopolyAutomate.Properties;
using ConsoleMonopolyAutomate.Players;

namespace ConsoleMonopolyAutomate
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMonopoly();
        }

        static void GameMonopoly()
        {

            Game game = new Game();

            game.SetGameProperties();
            game.StartingGame();

            Player[] players = game.Players;
            int numberPlayers = game.NumberOfPlayers;

            Property[] board = game.InizializeBoard();

            int i = 1;

            // Itracion por ronda
            while (i < game.NumberOfRounds + 1)
            {
                // Iteración por jugadores
                for(int e = 0; e < game.NumberOfPlayers; e++) 
                {
                    Player current_player = players[e];

                        // Player header method
                        /*Console.WriteLine($"{current_player.Player_number}, it's your turn!" +
                                        $"\nYour are standing on {board[current_player.Position].Name}" +
                                        $"\nYour money: ${current_player.Money}" +
                                        $"\nWhat do you want to do? \n1) Roll dice");
                        */
                        // Build houses, consult unsold properties, consult your others' properties
                        // What happens when you don't have money to pay

                        // int player_choice = Convert.ToInt32(Console.ReadLine());

                        // Movement method


                    // Comenzamos pruebas arrojando dados hasta que se compren todas las propiedades
                    int dice_roll = game.rollDice();
                    current_player.last_dice_roll = dice_roll;

                    Console.WriteLine($"Player {current_player.Player_number} rolled a {dice_roll}!");
                    current_player.Position = dice_roll + current_player.Position;

                    int current_position = current_player.Position;
                    Console.WriteLine($"You are now standing on {board[current_position].Name}");
                    // End movement method

                    board[current_position].PropertyAction(current_player, players);

                    /*switch (board[current_position].Type)
                    {
                        case "Street":
                            Street current_street = (Street)board[current_position];
                            if (current_street.Owner == -1)
                            {
                                //Eventualmente, agregar tomador de decision si compra o no.
                                Console.WriteLine($"Nobody owns {current_street.Name} so you buy it for {current_street.CostBuy}");
                                current_street.BuyProperty(current_player);
                                Console.WriteLine($"You now have ${current_player.Money}");
                                // Create exception when the player does not have enough money
                            }
                            else if (current_street.Owner == current_player.Player_number)
                            {
                                Console.WriteLine("The property is yours!");
                            }
                            else
                            {
                                Console.WriteLine($"The property is owned by player {current_street.Owner}");
                                Console.WriteLine($"You must pay him {current_street.TotalRent()}");
                                current_street.RentPayment(players[current_street.Owner-1], current_player);
                                Console.WriteLine($"The owner, {players[current_street.Owner - 1].Player_number} now has {players[current_street.Owner - 1].Money}");
                            }
                            break;
                    }*/
                }
                Console.WriteLine($"Terminó la ronda {i}");
                Console.WriteLine("");
                i++;
            }
            game.PrintStats(players);
        }
    }
}