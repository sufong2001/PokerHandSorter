using Poker.Domain;
using System.Collections.Generic;

namespace Poker.Application.Data
{
    /// <summary>
    /// The definition of Hand Reader common interface
    /// </summary>
    public interface IHandReader
    {
        IEnumerable<Hand[]> GetHandSet();
    }
}