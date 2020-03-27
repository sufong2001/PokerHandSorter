using Poker.Application.Rules;
using Poker.Domain;

namespace Poker.Application.Evaluator.Categorisers
{
    public class HandCategoriserChain : IHandEvaluator
    {
        private HandCategoriser Head { get; }

        public HandCategoriserChain()
        {
            Head = new RoyalFlushCategoriser(new RoyalFlushRule());
            Head.RegisterNext(new StraightFlushCategoriser(new StraightFlushRule()))
                .RegisterNext(new FourOfAKindCategoriser(new FourOfAKindRule()))
                .RegisterNext(new FullHouseCategoriser(new FullHouseRule()))
                .RegisterNext(new FlushCategoriser(new FlushRule()))
                .RegisterNext(new StraightCategoriser(new StraightRule()))
                .RegisterNext(new ThreeOfAKindCategoriser(new ThreeOfAKindRule()))
                .RegisterNext(new TwoPairsCategoriser(new TwoPairsRule()))
                .RegisterNext(new PairCategoriser(new PairRule()))
                .RegisterNext(new HighCardCategoriser(new HighCardRule()));
        }

        /// <summary>
        /// Evaluate a Hand and return the given Hand with a ranking
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public Hand Evaluate(Hand hand)
        {
            return Head.Categorise(hand);
        }
    }
}