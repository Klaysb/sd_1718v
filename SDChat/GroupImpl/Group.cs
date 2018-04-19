using System.Collections.Concurrent;

namespace GroupImpl
{
    public class Group
    {
        public int Owner { get; }
        public string Name { get; }
        public ConcurrentDictionary<int, int> UsersInSameRegion { get; set; } = new ConcurrentDictionary<int, int>();
        public ConcurrentDictionary<int, int> UsersInAnotherRegion { get; set; } = new ConcurrentDictionary<int, int>();

        public Group(int owner, string name)
        {
            Owner = owner;
            Name = name;
        }
    }
}
