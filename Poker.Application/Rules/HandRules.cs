using Poker.Domain;
using System.Linq;

namespace Poker.Application.Rules
{
    /// <summary>
    /// High Card which applies the base rule.
    /// </summary>
    public class HighCardRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    /// <summary>
    /// Pair which applies the highest pair value.
    /// </summary>
    public class PairRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var pairHighestX = x.Pairs.Max();
            var pairHighestY = y.Pairs.Max();

            return EvaluateHighestValue(new[] { pairHighestX }, new[] { pairHighestY });
        }
    }

    /// <summary>
    /// Two Pairs which applies the highest pair value.
    /// </summary>
    public class TwoPairsRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var pairsX = x.Pairs.ToArray();
            var pairsY = y.Pairs.ToArray();

            return EvaluateHighestValue(pairsX, pairsY);
        }
    }

    /// <summary>
    /// Three of a Kind which applies the highest value.
    /// </summary>
    public class ThreeOfAKindRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.ThreeOfAKind.ToArray();
            var kindY = y.ThreeOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    /// <summary>
    /// Straight which applies the base rule.
    /// </summary>
    public class StraightRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    /// <summary>
    /// Flush which applies the base rule.
    /// </summary>
    public class FlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    /// <summary>
    /// Full house which applies the highest value.
    /// </summary>
    public class FullHouseRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.ThreeOfAKind.ToArray();
            var kindY = y.ThreeOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    /// <summary>
    /// Four of a Kind which applies the highest value.
    /// </summary>
    public class FourOfAKindRule : RuleBase
    {
        public override int EvaluateNonSingle(Hand x, Hand y)
        {
            var kindX = x.FourOfAKind.ToArray();
            var kindY = y.FourOfAKind.ToArray();

            return EvaluateHighestValue(kindX, kindY);
        }
    }

    /// <summary>
    /// Straight Flush which applies the base rule.
    /// </summary>
    public class StraightFlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }

    /// <summary>
    /// Royal Flush which applies the base rule.
    /// </summary>
    public class RoyalFlushRule : RuleBase
    {
        // reuse base rule to evaluate single cards
    }
}