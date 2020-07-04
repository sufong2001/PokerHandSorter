namespace Poker.Domain
{
    /// <summary>
    /// Represent a card has value and suit  
    /// </summary>
    public class Card
    {
        public Card(Value val, Suit suit)
        {
            Suit = suit;
            Value = val;
        }

        public Suit Suit { get; }

        public Value Value { get; }
    }
}