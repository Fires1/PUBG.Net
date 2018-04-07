using System;
using System.Collections.Generic;

namespace PUBGLibrary.Core
{
    public class Match
    {
        public DateTime CreatedAt { get; set; }
        public int Duration { get; set; }
        public Gamemode Gamemode { get; set; }
        public Shard Shard { get; set; }
        public List<Participant> Participants { get; set; }
        public Uri Telemetry { get; set; }
    }
}
