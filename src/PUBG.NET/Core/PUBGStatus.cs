using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PUBGLibrary.Core
{
    public class PUBGStatus
    {
        public bool IsOnline = false;
        public DateTime APIVersionRelease;
        public string Version;

        public PUBGStatus Refresh()
        {
            var webRequest = System.Net.WebRequest.Create("https://api.playbattlegrounds.com/status");
            webRequest.Method = "GET";
            webRequest.Timeout = 20000;
            webRequest.ContentType = "application/json";
            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    IsOnline = true;
                    JObject status = JObject.Parse(jsonResponse);
                    APIVersionRelease = (DateTime)status["data"]["attributes"]["releasedAt"];
                    Version = (string)status["data"]["attributes"]["version"];
                    return this;
                }
            }
        }
    }
}
