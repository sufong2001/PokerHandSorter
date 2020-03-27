namespace Poker.Domain
{
    public interface IRule
    {
        int Evaluate(Hand x, Hand y);
    }
}