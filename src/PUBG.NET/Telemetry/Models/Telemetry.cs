using PUBGLibrary.Telemetry;
using System.Collections.Generic;

namespace PUBGLibrary.Telemetry
{
    public class Telemetry
    {
        //oh boy
        public string MatchId { get; set; }
        public IEnumerable<IEvent> Events { get; set; }
    }
}
