namespace PUBGLibrary.Core
{
    public struct PUBGClientConfig
    {
        public string Key;
        public Shard Shard;

        public PUBGClientConfig(string Key)
        {
            this.Key = Key;
            Shard = Shard.PC_NA;
        }

        public PUBGClientConfig(Shard Shard)
        {
            this.Shard = Shard;
            Key = null;
        }

        public PUBGClientConfig(string Key, Shard Shard)
        {
            this.Key = Key;
            this.Shard = Shard;
        }
    }
}
