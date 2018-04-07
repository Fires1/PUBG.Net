using PUBGLibrary.Telemetry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using PUBGLibrary.Telemetry;
using PUBGLibrary.Telemetry;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace PUBGLibrary.Telemetry
{
    //predications at 12:12am, the creation of this file.
    //im going to predict at the end of this i'm going to want to fucking kill myself because of how shitty this will be to deal with
    //TEN MEGABYTES OF FUCKING JSON DATA
    //T
    //E
    //N
    public class TelemetryService
    {
        public string DownloadTelemetry(Uri location, string disklocation = "pubgnet/")
        {
            if (disklocation == "pubgnet/")
            {
                if (!Directory.Exists("pubgnet"))
                {
                    Directory.CreateDirectory("pubgnet");
                }
            }
            else
            {
                //I have no idea if this code works.
                if (!Directory.Exists(disklocation))
                {
                    Directory.CreateDirectory(disklocation);
                }
            }
            using (WebClient c = new WebClient())
            {
                c.DownloadFile(location.AbsoluteUri, disklocation + $"/{location.Segments.Last()}.json");
                return disklocation + $"/{location.Segments.Last()}.json";
            }
        }
        public Telemetry Parse(string disklocation)
        {
            Telemetry telemetry = new Telemetry();
            string json = File.ReadAllText(disklocation);
            JArray jsobj = JArray.Parse(json);
            var list = new List<IEvent>();
            foreach (JObject obj in jsobj)
            { 
                EventType type = (EventType)System.Enum.Parse(typeof(EventType), obj.Value<string>("_T"));
                //best solution? switch.
                IEvent ev;
                //Only setting to IEvent to supress issue in line 162
                Type deserializertype = typeof(IEvent);
                switch (type)
                {
                    case EventType.LogCarePackageLand:
                        ev = new LogCarePackageLand();
                        deserializertype = typeof(LogCarePackageLand);
                        break;
                    case EventType.LogCarePackageSpawn:
                        ev = new LogCarePackageSpawn();
                        deserializertype = typeof(LogCarePackageSpawn);
                        break;
                    case EventType.LogGameStatePeriodic:
                        ev = new LogGameStatePeriodic();
                        deserializertype = typeof(LogGameStatePeriodic);
                        break;
                    case EventType.LogItemAttach:
                        ev = new LogItemAttach();
                        deserializertype = typeof(LogItemAttach);
                        break;
                    case EventType.LogItemDetach:
                        ev = new LogItemDetach();
                        deserializertype = typeof(LogItemDetach);
                        break;
                    case EventType.LogItemDrop:
                        ev = new LogItemDrop();
                        deserializertype = typeof(LogItemDrop);
                        break;
                    case EventType.LogItemEquip:
                        ev = new LogItemEquip();
                        deserializertype = typeof(LogItemEquip);
                        break;
                    case EventType.LogItemPickup:
                        ev = new LogItemPickup();
                        deserializertype = typeof(LogItemPickup);
                        break;
                    case EventType.LogItemUnequip:
                        ev = new LogItemUnequip();
                        deserializertype = typeof(LogItemUnequip);
                        break;
                    case EventType.LogItemUse:
                        ev = new LogItemUse();
                        deserializertype = typeof(LogItemUse);
                        break;
                    case EventType.LogMatchDefinition:
                        ev = new LogMatchDefinition();
                        deserializertype = typeof(LogMatchDefinition);
                        break;
                    case EventType.LogMatchEnd:
                        ev = new LogMatchEnd();
                        deserializertype = typeof(LogMatchEnd);
                        break;
                    case EventType.LogMatchStart:
                        ev = new LogItemDetach();
                        deserializertype = typeof(LogItemDetach);
                        break;
                    case EventType.LogPlayerAttack:
                        ev = new LogPlayerAttack();
                        deserializertype = typeof(LogPlayerAttack);
                        break;
                    case EventType.LogPlayerCreate:
                        ev = new LogItemEquip();
                        deserializertype = typeof(LogItemEquip);
                        break;
                    case EventType.LogPlayerKill:
                        ev = new LogPlayerKill();
                        deserializertype = typeof(LogPlayerKill);
                        break;
                    case EventType.LogPlayerLogin:
                        ev = new LogPlayerLogin();
                        deserializertype = typeof(LogPlayerLogin);
                        break;
                    case EventType.LogPlayerLogout:
                        ev = new LogPlayerLogout();
                        deserializertype = typeof(LogPlayerLogout);
                        break;
                    case EventType.LogPlayerPosition:
                        ev = new LogPlayerPosition();
                        deserializertype = typeof(LogPlayerPosition);
                        break;
                    case EventType.LogPlayerTakeDamage:
                        ev = new LogPlayerTakeDamage();
                        deserializertype = typeof(LogPlayerTakeDamage);
                        break;
                    case EventType.LogVehicleDestroy:
                        ev = new LogVehicleDestroy();
                        deserializertype = typeof(LogVehicleDestroy);
                        break;
                    case EventType.LogVehicleLeave:
                        ev = new LogVehicleLeave();
                        deserializertype = typeof(LogVehicleLeave);
                        break;
                    case EventType.LogVehicleRide:
                        ev = new LogVehicleRide();
                        deserializertype = typeof(LogVehicleRide);
                        break;
                    default:
                        throw new Exception("Unaccepted log!");

                }
                //nasty ^^
                //bout to get worse
                Type js = typeof(JsonConvert);
                var info = js.GetMethods().Where(x=>x.Name=="DeserializeObject" && x.IsGenericMethod).ToList();
                //Info returns 3 methods, all are overloads of DeserializeObject, the `0` index is the one we are looking for(single parameter, string). Likely a better way to do this?
                var geninfo = info[0].MakeGenericMethod(new Type[] { deserializertype });
                var jsss = obj.ToString();
                JObject jsobjs = JObject.Parse(jsss);
                if (jsobjs.Value<string>("damageTypeCategory") == "")
                {
                    jsobjs.Property("damageTypeCategory").Value = "Unknown";
                }
                IEvent objec = (IEvent)geninfo.Invoke(null, new object[] { jsobjs.ToString() });
                list.Add(objec);
            }
            return telemetry;
        }
    }
}
