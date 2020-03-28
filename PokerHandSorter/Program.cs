using Microsoft.Extensions.DependencyInjection;
using Poker.Application.Evaluator;
using Poker.Application.Evaluator.Categorisers;
using Poker.Data;
using Poker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandSorter
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = ResolveServiceProvider();
            var handEvaluator = serviceProvider.GetService<IHandEvaluator>();
            var winnerEvaluator = serviceProvider.GetService<IWinnerEvaluator>();
            var reader = serviceProvider.GetService<FileHandReader>();

            try
            {
                if (args.Length == 0)
                    throw new ArgumentNullException($"Data file name is required.");

                // game preparation
                var sorter = reader.Load(args[0]).GetHandSet();
                var players = new[] { new Player("1"), new Player("2") };

                // start simulation
                RunGame(players, sorter, handEvaluator, winnerEvaluator);

                // result
                ShowResult(players);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RunGame(IReadOnlyList<Player> players, IEnumerable<Hand[]> sorter, IHandEvaluator handEvaluator, IWinnerEvaluator winnerEvaluator)
        {
            // sorter gives hands to each game which will return a winner or null when it is tie.
            var winners = sorter.Select(EachGameWinner)
                .Where(w => w != null);

            // here is what happen in each game
            Player EachGameWinner(Hand[] hands)
            {
                // each player receive a hand
                var game = players.Select((p, i) => { p.Hand = hands[i]; return p; });

                // evaluate hand ranking on individual player by using HandCategoriserChain with Chain of Responsibility Pattern  
                game = game.Select(p => { p.Hand = handEvaluator.Evaluate(p.Hand); return p; });

                // evaluate the winner
                return winnerEvaluator.ShowWinner(game);
            }

            // winning count on total and individual player
            var totalGameHasWinner = winners.Sum(w =>
            {
                w.WinCount++;
                return 1;
            });

            // total number of tie if it is required
            var tie = sorter.Count() - totalGameHasWinner;
        }

        private static void ShowResult(Player[] players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Player {player.Name}: {player.WinCount}");
            }
        }

        private static ServiceProvider ResolveServiceProvider()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IHandEvaluator, HandCategoriserChain>()
                .AddSingleton<IWinnerEvaluator, WinnerEvaluator>()
                .AddTransient<FileHandReader>()
                ;
        }
    }
}