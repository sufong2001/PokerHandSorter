using System;
using System.Collections.Generic;
using System.Text;
using Poker.Domain;

namespace Poker.Application.Data
{
    public interface IHandReader
    {
        IEnumerable<Hand[]> GetHandSet();
    }
}
