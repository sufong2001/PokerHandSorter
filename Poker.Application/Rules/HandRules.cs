using System.Linq;
using Poker.Domain;

namespace Poker.Application.Rules
{
    public class HighCardRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    public class PairRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var pairHighestX = x.Pairs.Max();
            var pairHighestY = y.Pairs.Max();

            return EvaluateHighestValue(new[] { pairHighestX }, new[] { pairHighestY });
        }
    }

    public class TwoPairsRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var pairsX = x.Pairs.ToArray();
            var pairsY = y.Pairs.ToArray();

            return EvaluateHighestValue(pairsX, pairsY);
        }
    }

    public class ThreeOfAKindRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.ThreeOfAKind.ToArray();
            var kindY = y.ThreeOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    public class StraightRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    public class FlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    public class FullHouseRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.ThreeOfAKind.ToArray();
            var kindY = y.ThreeOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    public class FourOfAKindRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.FourOfAKind.ToArray();
            var kindY = y.FourOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    public class StraightFlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    public class RoyalFlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }
}