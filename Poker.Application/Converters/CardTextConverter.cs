using Poker.Domain;
using System;

namespace Poker.Application.Converters
{
    /// <summary>
    /// Extensions helper class for converting char and enum value
    /// </summary>
    public static class CardTextConverter
    {
        public static Value CharToValue(this char value) =>
        _ = value switch
        {
            '2' => Value.Two,
            '3' => Value.Three,
            '4' => Value.Four,
            '5' => Value.Five,
            '6' => Value.Six,
            '7' => Value.Seven,
            '8' => Value.Eight,
            '9' => Value.Nine,
            'T' => Value.Ten,
            'J' => Value.Jack,
            'K' => Value.King,
            'Q' => Value.Queen,
            'A' => Value.Ace,
            _   => throw new ArgumentException("Invalid Card Value!")
        };

        public static char ValueToChar(this Value value) =>
                _ = value switch
                {
                    Value.Two   => '2',
                    Value.Three => '3',
                    Value.Four  => '4',
                    Value.Five  => '5',
                    Value.Six   => '6',
                    Value.Seven => '7',
                    Value.Eight => '8',
                    Value.Nine  => '9',
                    Value.Ten   => 'T',
                    Value.Jack  => 'J',
                    Value.King  => 'K',
                    Value.Queen => 'Q',
                    Value.Ace   => 'A',
                    _           => throw new ArgumentException("Invalid Card Value!")
                };

        public static Suit CharToSuit(this char suit) =>
            _ = suit switch
            {
                'D' => Suit.Diamond,
                'H' => Suit.Heart,
                'S' => Suit.Spade,
                'C' => Suit.Club,
                _   => throw new ArgumentException("Invalid Card Suit!")
            };

        public static char SuitToChar(this Suit suit) =>
            _ = suit switch
            {
                Suit.Diamond => 'D',
                Suit.Heart   => 'H',
                Suit.Spade   => 'S',
                Suit.Club    => 'C',
                _            => throw new ArgumentException("Invalid Card Suit!")
            };
    }
}