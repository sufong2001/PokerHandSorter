using Poker.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Application.Evaluator
{
    public class WinnerEvaluator : IWinnerEvaluator
    {
        public Player ShowWinner(IEnumerable<Player> players)
        {
            // determine the winner by using the IComparable interface
            // sort the player by their rank
            var playerHandOrder = players.OrderByDescending(p => p.Hand).ToArray();
            var winner = playerHandOrder.First();

            var isTie = playerHandOrder.Skip(1).Any(p => winner.Hand.CompareTo(p.Hand) == 0);

            return isTie ? null : winner;
        }
    }
}