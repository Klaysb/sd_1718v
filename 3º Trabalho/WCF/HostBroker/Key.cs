using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HostBroker
{
    [DataContract]
    public class Key
    {
        [DataMember]
        public List<int> Indexes = new List<int>();

        [DataMember]
        public List<string> Storages = new List<string>();
    }
}
