using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Domain;

namespace Poker.Application.Converters
{
    public static class HandTextConverter
    {
        /// <summary>
        /// Convert an array of card string to Hand object. e.g. ["4D", "6S", "9H", "QH", "QC"]
        /// </summary>
        /// <param name="cardList"> An array of card string</param>
        /// <returns></returns>
        public static Hand StringToHand(this string[] cardList)
        {
            var cards = cardList.Select(c =>
            {
                var v = c.First().CharToValue();
                var s = c.Last().CharToSuit();

                return new Card(v, s);
            }).ToArray();


            return new Hand(cards);
        }
}
}
