using Microsoft.Extensions.DependencyInjection;
using Poker.Application.Evaluator;
using Poker.Application.Evaluator.Categorisers;
using Poker.Data;
using Poker.Domain;
using System;
using System.Collections.Generic;

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

                var sorter = reader.Load(args[0]).GetHandSet();
                var players = new[] { new Player("1"), new Player("2") };

                RunGame(players, sorter, handEvaluator, winnerEvaluator);

                ShowResult(players);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RunGame(IReadOnlyList<Player> players, IEnumerable<Hand[]> sorter, IHandEvaluator handEvaluator, IWinnerEvaluator winnerEvaluator)
        {
            foreach (var hands in sorter)
            {
                // distribute hand to player and evaluate the ranking
                for (var i = 0; i < players.Count; i++)
                {
                    players[i].Hand = handEvaluator.Evaluate(hands[i]);
                }

                var winner = winnerEvaluator.ShowWinner(players);

                if (winner != null) winner.WinCount++;
            }
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