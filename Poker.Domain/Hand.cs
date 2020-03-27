using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain
{
    public class Hand : IComparable<Hand>
    {
        private readonly Card[] _cards = new Card[5];

        public Hand(IEnumerable<Card> cards)
        {
            if (cards.Count() != _cards.Length)
                throw new ArgumentException("A hand must contains 5 cards!");

            _cards = cards.ToArray();
        }

        public HandRanking Rank { get; private set; }

        public IRule Rule { get; private set; }

        public void SetRankAndRule(HandRanking rank, IRule rule)
        {
            Rank = rank;
            Rule = rule;
        }

        public int CompareTo(Hand other)
        {
            return Rule.Evaluate(this, other);
        }


        public Card HighCard => SingleCards.OrderByDescending(c => c.Value).FirstOrDefault();

        public IEnumerable<Card> Cards => _cards;

        public IEnumerable<Card> SortCardsByDescending => _cards.OrderByDescending(c => c.Value);

        public IEnumerable<IGrouping<Value, Card>> GroupCards => SortCardsByDescending.GroupBy(c => c.Value);

        public IEnumerable<Card> SingleCards => GroupCards.Where(g => g.Count() == 1).SelectMany(g => g);

        public IEnumerable<Value> SingleCardValues => SingleCards.Select(c => c.Value);

        public IEnumerable<Value> Pairs => GroupCards.Where(g => g.Count() == 2).Select(g => g.Key);

        public IEnumerable<Value> ThreeOfAKind => GroupCards.Where(g => g.Count() == 3).Select(g => g.Key);

        public IEnumerable<Value> FourOfAKind => GroupCards.Where(g => g.Count() == 4).Select(g => g.Key);

        public bool HasNumberOfKind(int n)
        {
            var val = GroupCards
                .Any(g => g.Count() == n);

            return val;
        }

        public bool HasStraight
        {
            get
            {
                var singleCards = SingleCardValues.ToArray();

                if (singleCards.Length != Cards.Count()) return false;

                var max = singleCards.Max();
                var min = singleCards.Min();

                var val = (int)max - singleCards.Length == (int)min - 1;

                return val;
            }
        }

        public bool HasFlush
        {
            get
            {
                var val = Cards.GroupBy(c => c.Suit).Count() == 1;

                return val;
            }
        }
    }
}