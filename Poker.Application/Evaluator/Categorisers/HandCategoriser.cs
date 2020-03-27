using Poker.Domain;

namespace Poker.Application.Evaluator.Categorisers
{
    public abstract class HandCategoriser
    {
        protected HandCategoriser Next { get; private set; }
        protected IRule Rule { get; private set; }

        protected HandCategoriser(IRule rule)
        {
            Rule = rule;
        }

        public HandCategoriser RegisterNext(HandCategoriser next)
        {
            Next = next;
            return Next;
        }

        public abstract Hand Categorise(Hand hand);

        protected Hand SetHandRanking(Hand hand, HandRanking ranking)
        {
            var update = new Hand(hand.Cards);
            update.SetRankAndRule(ranking, Rule);

            return update;
        }
    }
}