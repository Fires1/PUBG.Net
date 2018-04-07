using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PUBGLibrary.Core
{
    public class Player
    {
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Username { get; set; }
        [JsonProperty("shardId")]
        public string Shard { get; set; }//This isn't working for some reason as Shard type. Investigate!!!
        [JsonProperty("Stats")]
        public object Statistics { get { throw new NotImplementedException(); } set { } }
        public IEnumerable<string> Matches { get; set; } //Build a way to instead have a list of the actual "Match" class, worth it for the time it takes to request? Not sure
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{Username} - {Shard} - {Id}";
        }
    }
}
