namespace PUBGLibrary.Core
{
    public class Participant
    {
        public string Actor { get; set; }
        public Shard Shard { get; set; }
        public ParticipantStats Stats { get; set; }
    }
}
