using System.Linq;
using Poker.Domain;

namespace Poker.Application.Evaluator.Categorisers
{
    public class HighCardCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return SetHandRanking(hand, HandRanking.HighCard);
        }

        public HighCardCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class PairCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(2) ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.Pair);
        }

        public PairCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class TwoPairsCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return hand.Pairs.Count() != 2 ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.TwoPairs);
        }

        public TwoPairsCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class ThreeOfAKindCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(3) ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.ThreeOfAKind);
        }

        public ThreeOfAKindCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class StraightCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasStraight ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.Straight);
        }

        public StraightCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class FlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasFlush ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.Flush);
        }

        public FlushCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class FullHouseCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasNumberOfKind(3) || !hand.HasNumberOfKind(2))
                return Next.Categorise(hand);

            return SetHandRanking(hand, HandRanking.FullHouse);
        }

        public FullHouseCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class FourOfAKindCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            return !hand.HasNumberOfKind(4) ? Next.Categorise(hand) : SetHandRanking(hand, HandRanking.FourOfAKind);
        }

        public FourOfAKindCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class StraightFlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasStraight || !hand.HasFlush)
                return Next.Categorise(hand);

            return SetHandRanking(hand, HandRanking.StraightFlush);
        }

        public StraightFlushCategoriser(IRule rule) : base(rule)
        {
        }
    }

    public class RoyalFlushCategoriser : HandCategoriser
    {
        public override Hand Categorise(Hand hand)
        {
            if (!hand.HasStraight || hand.SingleCardValues.Max() != Value.Ace ||  !hand.HasFlush)
                return Next.Categorise(hand);

            return SetHandRanking(hand, HandRanking.RoyalFlush);
        }

        public RoyalFlushCategoriser(IRule rule) : base(rule)
        {
        }
    }
}