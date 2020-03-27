using Poker.Domain;

namespace Poker.Application.Evaluator
{
    public interface IHandEvaluator
    {
        Hand Evaluate(Hand hand);
    }
}