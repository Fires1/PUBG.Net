using PUBGLibrary.Telemetry;
using System;

namespace PUBGLibrary.Telemetry
{
    public interface IEvent
    {
        EventType EventType { get; set; }
        DateTime EventTimestamp { get; set; }
        int EventVersion { get; set; }
        Common EventCommon { get; set; }
    }
}
