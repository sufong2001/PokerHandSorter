using Poker.Domain;

namespace Poker.Application.Evaluator
{
    /// <summary>
    /// The definition of Hand Evaluator common interface
    /// </summary>
    public interface IHandEvaluator
    {
        Hand Evaluate(Hand hand);
    }
}