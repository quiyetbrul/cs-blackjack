using System;

/*
    An object of type Deck represents a deck of 52 playing cards.
    The deck can be shuffled, and cards can be dealt from the deck.
*/

public class Deck
{

    private Card[] deck;   // An array of 52 Cards, representing the deck.
    private int cardsUsed; // How many cards have been dealt from the deck.

    public Deck()
    {
        deck = new Card[52];

        int cardCount = 0;
        for (int suit = 0; suit <= 3; suit++)
        {
            for (int value = 1; value <= 13; value++)
            {
                deck[cardCount] = new Card(value, (Suit)suit);
                cardCount++;
            }
        }

        cardsUsed = 0;
    }

    public void Shuffle()
    {

        // Put all the used cards back into the deck, and shuffle it into
        // a random order.

        Random r = new Random();

        for (int i = 51; i > 0; i--)
        {
            int rand = r.Next(0, i + 1);

            Card temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
        cardsUsed = 0;
    }

    public int CardsLeft()
    {
        return 52 - cardsUsed;
    }

    public Card DealCard()
    {
        // Deals one card from the deck and returns it.
        if (cardsUsed == 52)
            Shuffle();
        cardsUsed++;

        return deck[cardsUsed - 1];
    }

}