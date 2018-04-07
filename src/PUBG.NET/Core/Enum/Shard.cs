using Newtonsoft.Json;
using System.ComponentModel;

namespace PUBGLibrary.Core
{
    public enum Shard
    {
        /// <summary>
        /// PC North America
        /// </summary> 
        [JsonProperty("pc-na")] //As much as I hate these, we have to keep them included.
        [Description("pc-na")]
        PC_NA,
        /// <summary>
        /// PC Europe
        /// </summary>
        [JsonProperty("pc-eu")]
        [Description("pc-eu")]
        PC_EU,
        /// <summary>
        /// PC Korea/Japan
        /// </summary>
        [JsonProperty("pc-krjp")]
        [Description("pc-krjp")]
        PC_KRJP,
        /// <summary>
        /// PC Asia
        /// </summary>
        [JsonProperty("pc-as")]
        [Description("pc-as")]
        PC_AS,
        /// <summary>
        /// PC Oceania
        /// </summary>
        [JsonProperty("pc-oc")]
        [Description("pc-oc")]
        PC_OC,
        /// <summary>
        /// PC South and Central Amercia
        /// </summary>
        [JsonProperty("pc-sa")]
        [Description("pc-sa")]
        PC_SA,
        /// <summary>
        /// PC South East Asia
        /// </summary>
        [JsonProperty("pc-sea")]
        [Description("pc-sea")]
        PC_SEA,
        /// <summary>
        /// Alternative platform to Steam (https://www.kakaogames.com/)
        /// </summary>
        [JsonProperty("pc-kakao")]
        [Description("pc-kakao")]
        PC_KAKAO,
        /// <summary>
        /// Xbox North America
        /// </summary>
        [JsonProperty("xb-na")]
        [Description("xb-na")]
        Xbox_NA,
        /// <summary>
        /// Xbox Europe
        /// </summary>
        [JsonProperty("xb-eu")]
        [Description("xb-eu")]
        Xbox_EU,
        /// <summary>
        /// Xbox Asia
        /// </summary>
        [JsonProperty("xb-as")]
        [Description("xb-as")]
        Xbox_AS,
        /// <summary>
        /// Xbox Oceania
        /// </summary>
        [JsonProperty("xb-oc")]
        [Description("xb-oc")]
        Xbox_OC
    }
}
