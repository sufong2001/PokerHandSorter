using Poker.Application.Converters;
using Poker.Application.Data;
using Poker.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Poker.Data
{
    /// <summary>
    /// The implementation of a hand reader which allows to read hand data from a specified file format.
    /// </summary>
    public class FileHandReader : IHandReader
    {
        protected string[] HandList { get; private set; } = new string[0];

        public FileHandReader()
        {
        }

        public FileHandReader Load(string filePath)
        {
            HandList = File.ReadAllLines(filePath);

            return this;
        }

        public IEnumerable<Hand[]> GetHandSet()
        {
            var list = HandList
                .Select(l =>
                {
                    var cards = l.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var set1 = cards.Take(5).ToArray();
                    var set2 = cards.Skip(5).Take(5).ToArray();

                    return new[]
                    {
                        set1.StringToHand(),
                        set2.StringToHand(),
                    };
                });

            return list.ToArray();
        }
    }
}