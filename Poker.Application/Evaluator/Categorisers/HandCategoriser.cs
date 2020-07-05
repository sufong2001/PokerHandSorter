using Poker.Domain;

namespace Poker.Application.Evaluator.Categorisers
{
    /// <summary>
    /// HandCategoriser is an abstract class which defines the common functions of a hand catgoriser
    /// for chain responisbility setup.
    /// </summary>
    public abstract class HandCategoriser
    {
        public abstract Hand Categorise(Hand hand);

        protected HandCategoriser Next { get; private set; }
        protected IRule Rule { get; private set; }

        /// <summary>
        /// Constrauctor to set the assocaited rule
        /// </summary>
        /// <param name="rule"></param>
        protected HandCategoriser(IRule rule)
        {
            Rule = rule;
        }

        /// <summary>
        /// Allow to register next Hand Categoriser into the categoriser chain.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public HandCategoriser RegisterNext(HandCategoriser next)
        {
            Next = next;
            return Next;
        }

        /// <summary>
        /// Allow a categoriser to recreate a hand with rank and rule after has been categorised
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        protected Hand SetHandRank(Hand hand, Rank rank)
        {
            var update = new Hand(hand.Cards);
            update.SetRankAndRule(rank, Rule);

            return update;
        }
    }
}