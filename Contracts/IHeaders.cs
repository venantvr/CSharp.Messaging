using System;

namespace Contracts
{
    public interface IHeaders
    {
        DateTime Date { get; set; }
        string CorrelationId { get; }
    }
}