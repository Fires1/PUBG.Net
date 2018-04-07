using System.Collections.Generic;

namespace PUBGLibrary.Telemetry
{
    public class Item
    {
        public string ItemId { get; set; }
        public int StackCount { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<string> AttachedItems { get; set; }
    }
}
