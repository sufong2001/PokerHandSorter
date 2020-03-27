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
            var evaluator = serviceProvider.GetService<IHandEvaluator>();
            var reader = serviceProvider.GetService<FileHandReader>();

            try
            {
                if (args.Length == 0)
                    throw new ArgumentNullException($"Data file name is required.");

                var sorter = reader.Load(args[0]).GetHandSet();
                var players = new[] { new Player("1"), new Player("2") };

                RunGame(players, sorter, evaluator);

                ShowResult(players);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RunGame(IReadOnlyList<Player> players, IEnumerable<Hand[]> sorter, IHandEvaluator evaluator)
        {
            foreach (var hands in sorter)
            {
                // distribute the hand to player
                for (var i = 0; i < players.Count; i++)
                {
                    players[i].Hand = evaluator.Evaluate(hands[i]);
                }

                // determine the winner by using the IComparable interface
                // sort the player by their rank
                var playerHandOrder = players.OrderByDescending(p => p.Hand).ToArray();
                var winner = playerHandOrder.First();

                var isTie = playerHandOrder.Skip(1).Any(p => winner.Hand.CompareTo(p.Hand) == 0);

                if (!isTie) winner.WinCount++;
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
                .AddTransient<FileHandReader>()
                ;
        }
    }
}