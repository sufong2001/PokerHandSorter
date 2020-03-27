using System.Collections;
using System.Collections.Generic;

namespace Poker.UnitTests.TestData
{
    public class WinnerSampleDataSet : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "4H 4C 6S 7S KD", "2C 3S 9S 9D TD", 2 },
            new object[] { "5D 8C 9S JS AC", "2C 5C 7D 8S QH", 1 },
            new object[] { "2D 9C AS AH AC", "3D 6D 7D TD QD", 2 },
            new object[] { "4D 6S 9H QH QC", "3D 6D 7H QD QS", 1 },
            new object[] { "2H 2D 4C 4D 4S", "3C 3D 3S 9S 9D", 1 },
            new object[] { "KH KD 4C 4D 5S", "KC KS 3S 3H 9D", 1 },
            new object[] { "KH KD 4C 4D 3S", "KC KS 4S 4H 5D", 2 },
            new object[] { "KH KD 4C 4D 3S", "KH KD 4C 4D 3S", 0 },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}