using Poker.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Poker.UnitTests.TestData
{
    public class HandRankDataSet : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "5D 8C 9S JS AC", Rank.HighCard     , Value.Ace   },
            new object[] { "4H 4C 6S 7S KD", Rank.Pair         , Value.King  },
            new object[] { "6D KD 6S AC KH", Rank.TwoPairs     , Value.Ace   },
            new object[] { "2C 7H 2D 2S TD", Rank.ThreeOfAKind , Value.Ten   },
            new object[] { "8H 9D TD JC QS", Rank.Straight     , Value.Queen },
            new object[] { "QH JD TD 9C 8S", Rank.Straight     , Value.Queen },
            new object[] { "2S QS 7S KS 5S", Rank.Flush        , Value.King  },
            new object[] { "2H 2D 4C 4D 4S", Rank.FullHouse    , Value.None  },
            new object[] { "AC AD AH AS 7H", Rank.FourOfAKind  , Value.Seven },
            new object[] { "3C 4C 5C 6C 7C", Rank.StraightFlush, Value.Seven },
            new object[] { "7C 6C 5C 4C 3C", Rank.StraightFlush, Value.Seven },
            new object[] { "TD JD QD KD AD", Rank.RoyalFlush   , Value.Ace   },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}