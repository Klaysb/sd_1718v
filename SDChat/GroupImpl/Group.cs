using System;

namespace GroupImpl
{
    [Serializable]
    public class Group
    {
        public int Owner { get; }
        public string Name { get; }

        public Group(int owner, string name)
        {
            Owner = owner;
            Name = name;
        }
    }
}
