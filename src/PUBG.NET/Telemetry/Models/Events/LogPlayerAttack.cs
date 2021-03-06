﻿using System;
using Newtonsoft.Json;
using PUBGLibrary.Telemetry;

namespace PUBGLibrary.Telemetry
{
    public class LogPlayerAttack : IEvent
    {
        [JsonProperty("_T")]
        public EventType EventType { get; set; }
        [JsonProperty("_D")]
        public DateTime EventTimestamp { get; set; }
        [JsonProperty("_V")]
        public int EventVersion { get; set; }
        [JsonProperty("Common")]
        public Common EventCommon { get; set; }
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public AttackType AttackType { get; set; }
        public Item Weapon { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
