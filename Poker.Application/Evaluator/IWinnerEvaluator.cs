using Poker.Domain;
using System.Collections.Generic;

namespace Poker.Application.Evaluator
{
    public interface IWinnerEvaluator
    {
        /// <summary>
        /// Determine who is the winner from a list of players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        Player ShowWinner(IEnumerable<Player> players);
    }
}