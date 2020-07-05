using Poker.Application.Evaluator;
using Poker.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Application.Simulator
{
    /// <summary>
    /// A poker game simulator with a provided hand evaluator engine and winner evaluator engine
    /// </summary>
    public class PokerGameSimulator
    {
        private readonly IHandEvaluator _handEvaluator;
        private readonly IWinnerEvaluator _winnerEvaluator;

        public PokerGameSimulator(IHandEvaluator handEvaluator, IWinnerEvaluator winnerEvaluator)
        {
            _handEvaluator = handEvaluator;
            _winnerEvaluator = winnerEvaluator;
        }

        /// <summary>
        /// Run the simulatiuon with a list of player and a sorter with all the cards
        /// </summary>
        /// <param name="players"></param>
        /// <param name="sorter"></param>
        public IEnumerable<Player> Run(IEnumerable<Player> players, IEnumerable<Hand[]> sorter)
        {
            // local function to determine who is the winner of each game
            Player EachGameWinner(Hand[] hands)
            {
                // each player receives a hand
                var game = players.Select((p, i) => { p.Hand = hands[i]; return p; });

                // evaluate hand rank on individual player by using HandCategoriserChain with Chain of Responsibility Pattern
                game = game.Select(p => { p.Hand = _handEvaluator.Evaluate(p.Hand); return p; });

                // evaluate the winner
                return _winnerEvaluator.ShowWinner(game);
            }

            var sorterArray = sorter as Hand[][] ?? sorter.ToArray();

            // sorter gives hands to each game which will return a winner or null when it is tie.
            var winners = sorterArray.Select(EachGameWinner)
                .Where(w => w != null);

            // winning count on total and individual player
            var totalGameHasWinner = winners.Sum(w =>
            {
                w.WinCount++;
                return 1;
            });

            // total number of tie if it is required
            var tie = sorterArray.Length - totalGameHasWinner;

            return players;
        }
    }
}