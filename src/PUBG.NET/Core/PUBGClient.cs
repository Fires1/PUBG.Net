using RestSharp;

namespace PUBGLibrary.Core
{
    /// <summary>
    /// The base client class for the PUBG API
    /// </summary>
    //todo comments
    public partial class PUBGClient
    {
        private RestClient client = new RestClient("https://api.playbattlegrounds.com/shards/");
        private PUBGClientConfig config;
        private PUBGStatus status = new PUBGStatus();
        public PUBGClient(PUBGClientConfig config)
        {
            this.config = config;
        }
    }
}
