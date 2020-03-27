namespace Poker.Domain
{
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