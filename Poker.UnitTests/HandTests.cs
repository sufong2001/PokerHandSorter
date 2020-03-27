using Poker.Application.Converters;
using Poker.Application.Evaluator;
using Poker.Application.Evaluator.Categorisers;
using Poker.Domain;
using Poker.UnitTests.TestData;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Poker.UnitTests
{
    public class HandTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IHandEvaluator _handEvaluator;

        public HandTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _handEvaluator = new HandCategoriserChain();
        }

        [Theory]
        [ClassData(typeof(HandRankingDataSet))]
        public void Should_GetCorrectRankAndHighCard_With_TestHandRankingData(string cards, HandRanking expectedRank, Value expectedValue)
        {
            var hand = cards.Split(" ").StringToHand();

            hand = _handEvaluator.Evaluate(hand);

            Assert.Equal(expectedRank, hand.Rank);
            Assert.Equal(expectedValue, hand.HighCard?.Value ?? Value.None);
        }

        [Theory]
        [ClassData(typeof(WinnerSampleDataSet))]
        public void Should_GetCorrectWinner_With_TestWinnerData(string player1, string player2, int expectedWinner)
        {
            var hand1 = _handEvaluator.Evaluate(player1.Split(" ").StringToHand());
            var hand2 = _handEvaluator.Evaluate(player2.Split(" ").StringToHand());

            var compare = hand1.CompareTo(hand2);

            var winner = compare switch
            {
                _ when compare > 0 => 1,
                _ when compare < 0 => 2,
                _ => 0
            };

            Assert.Equal(expectedWinner, winner);
        }

        [Theory]
        [ClassData(typeof(WinnerSampleDataSet))]
        public void Should_GetCorrectWinnerBySorting_With_TestWinnerData(string hand1, string hand2, int expectedWinner)
        {
            var player1 = new Player("1") { Hand = _handEvaluator.Evaluate(hand1.Split(" ").StringToHand()) };
            var player2 = new Player("2") { Hand = _handEvaluator.Evaluate(hand2.Split(" ").StringToHand()) };

            var players = new[] { player1, player2 };

            // sort the player by their rank
            var playerHandOrder = players.OrderByDescending(p => p.Hand).ToArray();
            var topPlayer = playerHandOrder.First();

            var hasTie = playerHandOrder.Skip(1).Any(p => topPlayer.Hand.CompareTo(p.Hand) == 0);

            var winner = hasTie ? "0" : topPlayer.Name;

            Assert.Equal($"{expectedWinner}", winner);
        }

        [Theory]
        [ClassData(typeof(ThirdPartyResultDataSet))]
        public void Should_MatchResult_With_TestThirdPartyResultData(string hand1, string hand2, int expectedWinner)
        {
            var player1 = new Player("1") { Hand = _handEvaluator.Evaluate(hand1.Split(" ").StringToHand()) };
            var player2 = new Player("2") { Hand = _handEvaluator.Evaluate(hand2.Split(" ").StringToHand()) };

            var players = new[] { player1, player2 };

            // sort the player by their rank
            var playerHandOrder = players.OrderByDescending(p => p.Hand).ToArray();
            var topPlayer = playerHandOrder.First();

            var hasTie = playerHandOrder.Skip(1).Any(p => topPlayer.Hand.CompareTo(p.Hand) == 0);

            var winner = hasTie ? "0" : topPlayer.Name;

            Assert.Equal($"{expectedWinner}", winner);
        }

        [Theory]
        [InlineData("2C 3C 4C 5C 6C 7C")]
        [InlineData("2C 3C 4C 5C")]
        public void Should_ThrowArgumentException_With_InvalidNoOfCards(string cards)
        {
            var exception = Assert.Throws<ArgumentException>(() => cards.Split(" ").StringToHand());
            Assert.Equal("A hand must contains 5 cards!", exception.Message);
        }
    }
}