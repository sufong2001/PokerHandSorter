namespace Poker.Domain
{
    /// <summary>
    /// A rule interface poker rule implementation
    /// </summary>
    public interface IRule
    {
        int Evaluate(Hand x, Hand y);
    }
}