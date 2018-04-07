﻿using System;
using Newtonsoft.Json;
using PUBGLibrary.Telemetry;

namespace PUBGLibrary.Telemetry
{
    public class LogCarePackageLand : IEvent
    {
        [JsonProperty("_T")]
        public EventType EventType { get; set; }
        [JsonProperty("_D")]
        public DateTime EventTimestamp { get; set; }
        [JsonProperty("_V")]
        public int EventVersion { get; set; }
        [JsonProperty("Common")]
        public Common EventCommon { get; set; }
        public ItemPackage ItemPackage { get; set; }
    }
}