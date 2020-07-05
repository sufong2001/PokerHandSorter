using Poker.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Application.Evaluator
{
    /// <summary>
    /// Implementation of a winner evaluator by utilising the IComparable<T> nature.
    /// </summary>
    public class WinnerEvaluator : IWinnerEvaluator
    {
        public Player ShowWinner(IEnumerable<Player> players)
        {
            // sort the player by their hand which is using Hand.CompareTo function
            var playerHandOrder = players.OrderByDescending(p => p.Hand).ToArray();
            
            // found the possible winner
            var winner = playerHandOrder.First();

            // check for tie
            var isTie = playerHandOrder.Skip(1).Any(p => winner.Hand.CompareTo(p.Hand) == 0);

            return isTie ? null : winner;
        }
    }
}