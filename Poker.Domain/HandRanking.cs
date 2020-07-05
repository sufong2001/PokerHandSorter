namespace Poker.Domain
{
    /// <summary>
    /// The rank of the hand
    /// </summary>
    public enum Rank
    {
        Unknown      ,
        HighCard     ,
        Pair         ,
        TwoPairs     ,
        ThreeOfAKind ,
        Straight     ,
        Flush        ,
        FullHouse    ,
        FourOfAKind  ,
        StraightFlush,
        RoyalFlush   ,
    }
}