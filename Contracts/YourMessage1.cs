using System;

namespace Contracts
{
    public class YourMessage1 : IHeaders
    {
        public string Text { get; set; }
        public string CorrelationId => "blahblah";
        public DateTime Date { get; set; }
    }
}