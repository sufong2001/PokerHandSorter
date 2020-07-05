namespace Poker.Domain
{
    /// <summary>
    /// The definition of poker rule common interface
    /// </summary>
    public interface IRule
    {
        int Evaluate(Hand x, Hand y);
    }
}