using Interfaces;
using System.Collections.Generic;

namespace GroupImpl
{
    public class Group
    {
        public string Name { get; set; }
        public int Owner { get; set; }
        public List<int> UsersInSameRegion { get; set; }
        public List<int> UsersInAnotherRegion { get; set; } 
    }
}
