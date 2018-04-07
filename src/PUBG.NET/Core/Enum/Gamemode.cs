using Newtonsoft.Json;
using System.ComponentModel;

namespace PUBGLibrary.Core
{
    public enum Gamemode
    {
        duo,
        [JsonProperty("duo-fpp")]
        [Description("duo-fpp")]
        duo_fpp,
        solo,
        [JsonProperty("solo-fpp")]
        [Description("solo-fpp")]
        solo_fpp,
        squad,
        [JsonProperty("squad-fpp")]
        [Description("squad-fpp")]
        squad_fpp
    }
}
