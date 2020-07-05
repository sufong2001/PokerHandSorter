using Microsoft.Extensions.DependencyInjection;
using Poker.Application.Evaluator;
using Poker.Application.Evaluator.Categorisers;
using Poker.Application.Simulator;
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
            var reader = serviceProvider.GetService<FileHandReader>();
            var simulator = serviceProvider.GetService<PokerGameSimulator>();

            try
            {
                if (args.Length == 0)
                    throw new ArgumentNullException($"Data file name is required.");

                // game preparation - load cards
                var sorter = reader.Load(args[0]).GetHandSet();
                var players = new[] { new Player("1"), new Player("2") };

                // start simulation
                var result = simulator.Run(players, sorter);

                // result
                ShowResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Helper function to show the player results
        /// </summary>
        /// <param name="players"></param>
        private static void ShowResult(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Player {player.Name}: {player.WinCount}");
            }
        }

        /// <summary>
        /// Helper function to create service provider
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider ResolveServiceProvider()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Helper function to config DI service
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IHandEvaluator, HandCategoriserChain>()
                .AddSingleton<IWinnerEvaluator, WinnerEvaluator>()
                .AddTransient<FileHandReader>()
                .AddTransient<PokerGameSimulator>()
                ;
        }
    }
}