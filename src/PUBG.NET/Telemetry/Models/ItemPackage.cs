using System.Collections.Generic;

namespace PUBGLibrary.Telemetry
{
    public class ItemPackage
    {
        public string ItemPackageId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
