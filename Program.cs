using System;

namespace Blackjack

{
    class Program
    {
        static void Main(string[] args)
        {
            double pocketMoney = 100;
            double gambleMoney;

            do
            {
                System.Console.WriteLine($"\n~~Pocket Money: ${pocketMoney}~~" +
                "\n=======================================");

                    gambleMoney = inputDouble("Enter gamble money (Enter 0 to leave): ", 0, pocketMoney);
                    if (gambleMoney == 0) //exits the program
                    {
                        System.Console.WriteLine($"\n~You left the casino with ${pocketMoney}~");
                        System.Console.WriteLine("\n=======================================");
                        System.Environment.Exit(0);
                    }

                if (PlayBlackjack())
                {
                    pocketMoney += gambleMoney;
                    System.Console.WriteLine($"\n\t     ~~You won ${gambleMoney}~~");
                    System.Console.WriteLine($"\t     Total money: ${pocketMoney}");
                    System.Console.WriteLine("\n=======================================");
                }
                else
                {
                    pocketMoney -= gambleMoney;
                    System.Console.WriteLine($"\n\t     You lost ${gambleMoney}");
                    System.Console.WriteLine($"\t     Total money: ${pocketMoney}");
                    System.Console.WriteLine("\n=======================================");
                    if (pocketMoney == 0)
                    {
                        System.Console.WriteLine("\n=======================================\n" +
                        "\n\t     You're broke." +
                        "\n\t       Good-bye!\n" +
                        "\n=======================================\n");
                        System.Environment.Exit(0);
                    }
                }
            } while (pocketMoney > 0);

        }


        static bool PlayBlackjack()
        {
            Deck deck = new Deck();
            BlackjackHand userHand = new BlackjackHand();
            BlackjackHand dealerHand = new BlackjackHand();

            deck.Shuffle();

            userHand.AddCard(deck.DealCard());
            userHand.AddCard(deck.DealCard());

            dealerHand.AddCard(deck.DealCard());
            dealerHand.AddCard(deck.DealCard());

            if (dealerHand.GetBlackjackValue() == 21)
            {
                Console.WriteLine("\nDealer has the " + dealerHand.GetCard(0)
                                        + " and the " + dealerHand.GetCard(1) + ".");
                Console.WriteLine("User has the " + userHand.GetCard(0)
                                          + " and the " + userHand.GetCard(1) + ".");
                Console.WriteLine();
                Console.WriteLine("Dealer has Blackjack. Dealer wins.");
                System.Console.WriteLine("\n=======================================");
                return false;
            }

            if (userHand.GetBlackjackValue() == 21)
            {
                Console.WriteLine("\nDealer has the " + dealerHand.GetCard(0)
                                        + " and the " + dealerHand.GetCard(1) + ".");
                Console.WriteLine("User has the " + userHand.GetCard(0)
                                          + " and the " + userHand.GetCard(1) + ".");
                Console.WriteLine();
                Console.WriteLine("You have Blackjack. You win.");
                System.Console.WriteLine("\n=======================================");
                return true;
            }

            /*  If neither player has Blackjack, play the game.  First the user
                gets a chance to draw cards (i.e., to "Hit").  The while loop ends when the user chooses to "Stand".  If the user goes over 21, the user loses immediately.
            */

            while (true)
            {

                /* Display user's cards, and let user decide to Hit or Stand. */

                Console.WriteLine();
                Console.WriteLine("Your cards are:");

                for (int i = 0; i < userHand.GetCardCount(); i++)
                    Console.WriteLine("    " + userHand.GetCard(i));
                Console.WriteLine("Your total is " + userHand.GetBlackjackValue());
                Console.WriteLine();
                Console.WriteLine("Dealer is showing the " + dealerHand.GetCard(0));
                Console.WriteLine();
                Console.Write("Hit (H) or Stand (S)? ");

                string userAction;  // User's response, 'H' or 'S'.
                do
                {
                    userAction = Console.ReadLine().ToUpper();
                    if (userAction != "H" && userAction != "S")
                        Console.Write("\n==ERROR-2A: Invalid input. Respond with H or S:  ");
                } while (userAction != "H" && userAction != "S");

                /* If the user Hits, the user gets a card.  If the user Stands,
                   the loop ends (and it's the dealer's turn to draw cards).
                */

                if (userAction == "S")
                {
                    // Loop ends; user is done taking cards.
                    break;
                }
                else
                {  // userAction is 'H'.  Give the user a card.
                   // If the user goes over 21, the user loses.
                    Card newCard = deck.DealCard();
                    userHand.AddCard(newCard);

                    Console.WriteLine();
                    Console.WriteLine("User hits.");
                    Console.WriteLine("Your card is the " + newCard);
                    Console.WriteLine("Your total is now " +
                    userHand.GetBlackjackValue());

                    if (userHand.GetBlackjackValue() > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You busted by going over 21.  You lose.");
                        Console.WriteLine("Dealer's other card was the "
                                                           + dealerHand.GetCard(1));
                        System.Console.WriteLine("\n=======================================");
                        return false;
                    }
                }

            } // end while loop

            /* If we get to this point, the user has Stood with 21 or less.  Now, it's
               the dealer's chance to draw.  Dealer draws cards until the dealer's
               total is > 16.  If dealer goes over 21, the dealer loses.
            */

            Console.WriteLine();
            Console.WriteLine("User stands.");
            Console.WriteLine("Dealer's cards are");
            Console.WriteLine("    " + dealerHand.GetCard(0));
            Console.WriteLine("    " + dealerHand.GetCard(1));
            while (dealerHand.GetBlackjackValue() <= 16)
            {
                Card newCard = deck.DealCard();
                Console.WriteLine("Dealer hits and gets the " + newCard);
                dealerHand.AddCard(newCard);
                if (dealerHand.GetBlackjackValue() > 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Dealer busted by going over 21.  You win.");
                    System.Console.WriteLine("\n=======================================");
                    return true;
                }
            }
            Console.WriteLine("Dealer's total is " + dealerHand.GetBlackjackValue());

            /* If we get to this point, both players have 21 or less.  We
               can determine the winner by comparing the values of their hands. */

            Console.WriteLine();
            if (dealerHand.GetBlackjackValue() == userHand.GetBlackjackValue())
            {
                Console.WriteLine("Dealer wins on a tie.  You lose.");
                System.Console.WriteLine("\n=======================================");
                return false;
            }
            else if (dealerHand.GetBlackjackValue() > userHand.GetBlackjackValue())
            {
                Console.WriteLine("Dealer wins, " + dealerHand.GetBlackjackValue()
                                 + " points to " + userHand.GetBlackjackValue() + ".");
                System.Console.WriteLine("\n=======================================");
                return false;
            }
            else
            {
                Console.WriteLine("You win, " + userHand.GetBlackjackValue()
                                 + " points to " + dealerHand.GetBlackjackValue() + ".");
                System.Console.WriteLine("\n=======================================");
                return true;
            }

        }

        static double inputDouble(string prompt, double startRange, double endRange)
        {
            double userInput;
            bool selected = false;
            string ERROR_MESSAGE = $"\n==ERROR-1A: Invalid input. Must be from {startRange} - {endRange}.==\n";

            do
            {
                System.Console.Write(prompt);
                if (Double.TryParse(Console.ReadLine(), out userInput))
                {
                    if(userInput >= Math.Min(startRange, endRange) && userInput <= Math.Max(startRange,endRange)){
                        break;
                    }
                    else System.Console.WriteLine(ERROR_MESSAGE);
                }
                else System.Console.WriteLine(ERROR_MESSAGE);
            }while(!selected);

            return userInput;
        }
    }
}
