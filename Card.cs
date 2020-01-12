
/*
   An object of class Card represents one of the 52 cards in a
   standard deck of playing cards.  Each card has a suit and
   a value.
*/

public enum Suit { Spades, Hearts, Diamonds, Clubs };

public class Card {

    public Suit Suit { get; private set; }
    public int Value { get; private set; }

    public Card(int value, Suit suit) {
        Value = value;
        Suit = suit;
    }

    public string GetSuitAsString() {
        switch ( Suit ) {
           case Suit.Spades:   return "Spades";
           case Suit.Hearts:   return "Hearts";
           case Suit.Diamonds: return "Diamonds";
           case Suit.Clubs:    return "Clubs";
           default:            return "??";
        }
    }

    public string GetValueAsString() {
            // Return a String representing the card's value.
            // If the card's value is invalid, "??" is returned.
        switch ( Value ) {
           case 1:   return "Ace";
           case 2:   return "2";
           case 3:   return "3";
           case 4:   return "4";
           case 5:   return "5";
           case 6:   return "6";
           case 7:   return "7";
           case 8:   return "8";
           case 9:   return "9";
           case 10:  return "10";
           case 11:  return "Jack";
           case 12:  return "Queen";
           case 13:  return "King";
           default:  return "??";
        }
    }

    public override string ToString() {
        return GetValueAsString() + " of " + GetSuitAsString();
    }
}