using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

namespace PUBGLibrary.Core
{
    /*
        ==Why split into two files==
      * Easier to add/edit/remove methods.
      * Easier to add/edit/remove base client features.
      * Can easily be later extended to serve as a static "helper" class for multiple implementations of the client.
      * Can easily be split into files based on separate areas of the api(ex. matches, users, telemetry, replays)
     */
    public partial class PUBGClient
    {
        //We should probably follow my last comment above :)
        public Match GetMatch(string Id)
        {
            if (status.Refresh().IsOnline)
            {
                var request = new RestRequest(config.Shard.ToString().ToLower().Replace('_', '-') + "/matches/"+Id, Method.GET);
                request.AddHeader("Authorization", "Bearer " + config.Key);
                request.AddHeader("Accept", "application/json");
                IRestResponse res = client.Execute(request);
                var m = new Match();
                var jsobj = JObject.Parse(res.Content);
                m = JsonConvert.DeserializeObject<Match>(jsobj["data"]["attributes"].ToString());
                m.Participants = new List<Participant>();
                foreach (JObject p in jsobj["included"])
                {
                    if (p.Value<string>("type") == "participant")
                    {
                        m.Participants.Add(JsonConvert.DeserializeObject<Participant>(p["attributes"].ToString()));
                    }
                    if (p.Value<string>("type") == "asset")//telemetry
                    {
                        m.Telemetry = new Uri(p["attributes"].Value<string>("URL"));
                    }
                    //do stuff with rosters here
                }
                return m;
            }
            return null;
        }

        public Player GetPlayer(string AccountId)
        {
            if (status.Refresh().IsOnline)
            {
                var request = new RestRequest(config.Shard.ToString().ToLower().Replace('_', '-') + "/players/" + AccountId, Method.GET);
                request.AddHeader("Authorization", "Bearer " + config.Key);
                request.AddHeader("Accept", "application/json");
                IRestResponse res = client.Execute(request);
                var p = new Player();
                var jsobj = JObject.Parse(res.Content);
                p = JsonConvert.DeserializeObject<Player>(jsobj["data"]["attributes"].ToString());
                p.Id = jsobj["data"].Value<string>("id");
                var matches = new List<string>();
                foreach (var m in jsobj["data"]["relationships"]["matches"]["data"])
                {
                    matches.Add(m.Value<string>("id"));
                }
                p.Matches = matches;
                return p;
            }
            return null;
        }

        public IEnumerable<Player> GetPlayers(SearchType searchtype, params string[] input)
        {
            if (status.Refresh().IsOnline)
            {
                var players = new List<Player>();
                var request = new RestRequest(config.Shard.ToString().ToLower().Replace('_', '-') + "/players", Method.GET);
                request.AddHeader("Authorization", "Bearer " + config.Key);
                request.AddHeader("Accept", "application/json");
                switch (searchtype)
                {
                    case SearchType.Id:
                        request.AddParameter("filter[playerIds]", string.Join(",", input));
                        break;
                    case SearchType.Username:
                        request.AddParameter("filter[playerNames]", string.Join(",", input));
                        break;
                    default:
                        throw new ArgumentException("Missing search type, how do you even manage to throw this exception???"); //$5 paypal to first person who can throw this exception
                }
                IRestResponse res = client.Execute(request);
                var jsobj = JObject.Parse(res.Content);

                foreach (var pl in jsobj["data"])
                {
                    var p = new Player();
                    p = JsonConvert.DeserializeObject<Player>(pl["attributes"].ToString());
                    p.Id = pl.Value<string>("id");
                    var matches = new List<string>();
                    foreach (var m in pl["relationships"]["matches"]["data"])
                    {
                        matches.Add(m.Value<string>("id"));
                    }
                    p.Matches = matches;
                    players.Add(p);
                }
                return players;
            }
            return null;
        }
    }
}
