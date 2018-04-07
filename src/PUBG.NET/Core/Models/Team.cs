using System.Collections.Generic;

namespace PUBGLibrary.Core
{
    public class Team
    {
        public int Rank { get; set; }
        public int Id { get; set; }
        public bool Won { get; set; }
        public IEnumerable<string> Teammates { get; set; }

        public int Size
        {
            get
            {
                return ((string[])Teammates).Length;
            }
        }
    }
}
