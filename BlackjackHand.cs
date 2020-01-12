
/*
   A subclass of the Hand class that represents a hand of cards
   in the game of Blackjack.  To the methods inherited from Hand,
   it adds the method getBlackjackHand(), which returns the value
   of the hand for the game of Blackjack.
*/

public class BlackjackHand : Hand
{

    public int GetBlackjackValue()
    {
        // Returns the value of this hand for the
        // game of Blackjack.

        int val = 0;
        bool ace = false;  // This will be set to true if the
                           //   hand contains an ace.
        int cards = GetCardCount();

        for (int i = 0; i < cards; i++)
        {
            Card card = GetCard(i);
            int cardVal = card.Value;

            if (cardVal > 10)
            {
                cardVal = 10;   // For a Jack, Queen, or King.
            }
            if (cardVal == 1)
            {
                ace = true;     // There is at least one ace.
            }
            val = val + cardVal;
        }

        // Now, val is the value of the hand, counting any ace as 1.
        // If there is an ace, and if changing its value from 1 to
        // 11 would leave the score less than or equal to 21,
        // then do so by adding the extra 10 points to val.

        if (ace && val + 10 <= 21)
            val += 10;

        return val;

    }

}
