namespace PUBGLibrary.Telemetry
{
    public class GameState
    {
        public int ElapsedTime { get; set; }
        public int NumAliveTeams { get; set; }
        public int NumJoinPlayers { get; set; }
        public int NumStartPlayers { get; set; }
        public int NumAlivePlayers { get; set; }
        public Location SafetyZonePosition { get; set; }
        public float SafetyZoneRadius { get; set; }
        public Location PoisonGasWarningPosition { get; set; }
        public float PoisonGasWarningRadius { get; set; }
        public Location RedzonePosition { get; set; }
        public float RedZoneRadius { get; set; }
    }
}
