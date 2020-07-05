using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain
{
    /// <summary>
    /// A poker hand consists of a combination of five playing cards and able to compare to another hand
    /// according to the rank.
    /// </summary>
    public class Hand : IComparable<Hand>
    {
        private readonly Card[] _cards = new Card[5];

        public Hand(IEnumerable<Card> cards)
        {
            var enumerable = cards as Card[] ?? cards.ToArray();
            if (enumerable.Count() != _cards.Length)
                throw new ArgumentException("A hand must contains 5 cards!");

            _cards = enumerable.ToArray();
        }

        /// <summary>
        /// The rank of the hand according.
        /// </summary>
        public Rank Rank { get; private set; }

        /// <summary>
        /// A rule to be used for evaluating with another hand during comparison.
        /// </summary>
        public IRule Rule { get; private set; }

        /// <summary>
        /// An evaluator will use this method to set the rank and the rule after this hand has been evaluated.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="rule"></param>
        public void SetRankAndRule(Rank rank, IRule rule)
        {
            Rank = rank;
            Rule = rule;
        }

        /// <summary>
        /// Allows the rule evaluator to compare 2 hands according to rank.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>An integer that indicates whether this hand precedes.
        /// Less than zero : This hand lose.
        /// Zero : Two ranks tie.
        /// Greater than zero: This hand win.
        /// </returns>
        public int CompareTo(Hand other)
        {
            return Rule.Evaluate(this, other);
        }

        /// <summary>
        /// Highest value card
        /// </summary>
        public Card HighCard => SingleCards.OrderByDescending(c => c.Value).FirstOrDefault();

        /// <summary>
        /// The cards in hand
        /// </summary>
        public IEnumerable<Card> Cards => _cards;

        /// <summary>
        /// Sort the cards by descending order according to card value.
        /// </summary>
        public IEnumerable<Card> SortCardsByDescending => _cards.OrderByDescending(c => c.Value);

        /// <summary>
        /// Group the cards by card value.
        /// </summary>
        public IEnumerable<IGrouping<Value, Card>> GroupCards => SortCardsByDescending.GroupBy(c => c.Value);

        /// <summary>
        /// Find all single card in this hand.
        /// </summary>
        public IEnumerable<Card> SingleCards => GroupCards.Where(g => g.Count() == 1).SelectMany(g => g);

        /// <summary>
        /// Find all values of the single card in this hand.
        /// </summary>
        public IEnumerable<Value> SingleCardValues => SingleCards.Select(c => c.Value);

        /// <summary>
        /// Find all values of the pair card in this hand.
        /// </summary>
        public IEnumerable<Value> Pairs => GroupCards.Where(g => g.Count() == 2).Select(g => g.Key);

        /// <summary>
        /// Find the value of three of a kind in this hand.
        /// </summary>
        public IEnumerable<Value> ThreeOfAKind => GroupCards.Where(g => g.Count() == 3).Select(g => g.Key);

        /// <summary>
        /// Find the value of four of a kind in this hand.
        /// </summary>
        public IEnumerable<Value> FourOfAKind => GroupCards.Where(g => g.Count() == 4).Select(g => g.Key);

        /// <summary>
        /// Determines this hand which has the specified number of a kind
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool HasNumberOfKind(int n)
        {
            var val = GroupCards
                .Any(g => g.Count() == n);

            return val;
        }

        /// <summary>
        /// All five cards in consecutive value order in this hand.
        /// </summary>
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

        /// <summary>
        /// All five cards having the same suit in this hand
        /// </summary>
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