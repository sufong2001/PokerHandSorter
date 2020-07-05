using Poker.Domain;
using System.Linq;

namespace Poker.Application.Evaluator.Categorisers
{
    /// <summary>
    /// Responsible to categorise a hand is a high card
    /// </summary>
    public class HighCardCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return SetHandRank(hand, Rank.HighCard);
        }

        public HighCardCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a pair
    /// </summary>
    public class PairCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(2) ? Next.Categorise(hand) : SetHandRank(hand, Rank.Pair);
        }

        public PairCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a two pairs
    /// </summary>
    public class TwoPairsCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return hand.Pairs.Count() != 2 ? Next.Categorise(hand) : SetHandRank(hand, Rank.TwoPairs);
        }

        public TwoPairsCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a three of a kind
    /// </summary>
    public class ThreeOfAKindCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(3) ? Next.Categorise(hand) : SetHandRank(hand, Rank.ThreeOfAKind);
        }

        public ThreeOfAKindCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a straight
    /// </summary>
    public class StraightCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasStraight ? Next.Categorise(hand) : SetHandRank(hand, Rank.Straight);
        }

        public StraightCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a flush
    /// </summary>
    public class FlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasFlush ? Next.Categorise(hand) : SetHandRank(hand, Rank.Flush);
        }

        public FlushCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a full house
    /// </summary>
    public class FullHouseCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasNumberOfKind(3) || !hand.HasNumberOfKind(2))
                return Next.Categorise(hand);

            return SetHandRank(hand, Rank.FullHouse);
        }

        public FullHouseCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a four of a kind
    /// </summary>
    public class FourOfAKindCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(4) ? Next.Categorise(hand) : SetHandRank(hand, Rank.FourOfAKind);
        }

        public FourOfAKindCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a stright flush
    /// </summary>
    public class StraightFlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasStraight || !hand.HasFlush)
                return Next.Categorise(hand);

            return SetHandRank(hand, Rank.StraightFlush);
        }

        public StraightFlushCategoriser(IRule rule) : base(rule)
        {
        }
    }

    /// <summary>
    /// Responsible to categorise a hand is a three of a royal flush
    /// </summary>
    public class RoyalFlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasStraight || hand.SingleCardValues.Max() != Value.Ace || !hand.HasFlush)
                return Next.Categorise(hand);

            return SetHandRank(hand, Rank.RoyalFlush);
        }

        public RoyalFlushCategoriser(IRule rule) : base(rule)
        {
        }
    }
}