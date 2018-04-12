using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GroupImpl
{
    public class Group
    {
        private readonly int owner;
        public int Owner { get { return owner; } }
        private readonly string name;
        public string Name { get { return name; } }
        public ConcurrentDictionary<int, int> UsersInSameRegion { get; set; } = new ConcurrentDictionary<int, int>();
        public ConcurrentDictionary<int, int> UsersInAnotherRegion { get; set; } = new ConcurrentDictionary<int, int>();

        public Group(int owner, string name)
        {
            this.owner = owner;
            this.name = name;
        }
    }
}
