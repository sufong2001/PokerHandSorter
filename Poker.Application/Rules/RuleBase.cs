using Poker.Domain;
using System;
using System.Linq;

namespace Poker.Application.Rules
{
    /// <summary>
    /// The implmetation of the base rule of poker game
    /// </summary>
    public class RuleBase : IRule
    {
        /// <summary>
        /// Compare the hand between x and y and returns an integer that indicates whether
        /// the x is higher, tie or lower to y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Evaluate(Hand x, Hand y)
        {
            var evaluators = new Func<Hand, Hand, int>[]
             {
                EvaluateRank,
                EvaluateNonSingle,
                EvaluateSingle
             };

            return evaluators.Select(eval => eval(x, y)).FirstOrDefault(val => val != 0);
        }

        public virtual int EvaluateRank(Hand x, Hand y)
        {
            return x.Rank - y.Rank;
        }

        /// <summary>
        /// No evaluation logic by default and return 0 to skip the execution order
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual int EvaluateNonSingle(Hand x, Hand y)
        {
            return 0; 
        }

        public virtual int EvaluateSingle(Hand x, Hand y)
        {
            var handX = x.SingleCardValues.ToArray();
            var handY = y.SingleCardValues.ToArray();

            return EvaluateHighestValue(handX, handY);
        }

        /// <summary>
        /// Compare the highest value in x's stack and y's stack and returns an integer that indicates whether
        /// the x's value higher, tie or lower to y's value.
        /// </summary>
        /// <param name="cardsX"></param>
        /// <param name="cardsY"></param>
        /// <returns></returns>
        protected int EvaluateHighestValue(Value[] cardsX, Value[] cardsY)
        {
            // cardsX equals cardsY than tie
            if (cardsX.All(cardsY.Contains))
                return 0;

            var highX = cardsX.Except(cardsY).Max();
            var highY = cardsY.Except(cardsX).Max();

            return highX - highY;
        }
    }
}