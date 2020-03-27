using Poker.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Poker.UnitTests.TestData
{
    public class HandRankingDataSet : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "5D 8C 9S JS AC", HandRanking.HighCard     , Value.Ace   },
            new object[] { "4H 4C 6S 7S KD", HandRanking.Pair         , Value.King  },
            new object[] { "6D KD 6S AC KH", HandRanking.TwoPairs     , Value.Ace   },
            new object[] { "2C 7H 2D 2S TD", HandRanking.ThreeOfAKind , Value.Ten   },
            new object[] { "8H 9D TD JC QS", HandRanking.Straight     , Value.Queen },
            new object[] { "QH JD TD 9C 8S", HandRanking.Straight     , Value.Queen },
            new object[] { "2S QS 7S KS 5S", HandRanking.Flush        , Value.King  },
            new object[] { "2H 2D 4C 4D 4S", HandRanking.FullHouse    , Value.None  },
            new object[] { "AC AD AH AS 7H", HandRanking.FourOfAKind  , Value.Seven },
            new object[] { "3C 4C 5C 6C 7C", HandRanking.StraightFlush, Value.Seven },
            new object[] { "7C 6C 5C 4C 3C", HandRanking.StraightFlush, Value.Seven },
            new object[] { "TD JD QD KD AD", HandRanking.RoyalFlush   , Value.Ace   },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}