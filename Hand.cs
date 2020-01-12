using System;
using System.Linq;
using System.Collections.Generic;
/*
    An object of type Hand represents a hand of cards.  The maximum number of
    cards in the hand can be specified in the constructor, but by default
    is 5.
*/

public class Hand
{

    private List<Card> hand;   // The cards in the hand.

    public Hand()
    {
        // Create a Hand object that is initially empty.
        hand = new List<Card>();
    }

    public void Clear()
    {
        hand.Clear();
    }

    public void AddCard(Card c)
    {
        if (c != null)
            hand.Add(c);
    }

    public int GetCardCount()
    {
        // Return the number of cards in the hand.
        return hand.Count;
    }

    public Card GetCard(int position)
    {
        // Get the card from the hand in given position, where positions
        // are numbered starting from 0.
        if (position >= 0 && position < hand.Count)
            return (Card)hand.ElementAt(position);
        else
            return null;
    }


}