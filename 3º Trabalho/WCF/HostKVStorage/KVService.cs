using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using System.Threading;

namespace HostKVStorage
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class KVService : IKVService
    {
        private readonly ConcurrentDictionary<int, string> values = new ConcurrentDictionary<int, string>();
        private volatile int counter = -1;

        public void DeleteData(int key)
        {
            if (!values.TryRemove(key, out string value))
                throw new ArgumentException("Key not found");
        }

        public string RetrieveData(int key)
        {
            if (!values.TryGetValue(key, out string value))
                throw new ArgumentException("Key not found");
            return value;
        }

        public int StoreData(string value)
        {
            int key = Interlocked.Increment(ref counter);
            values.TryAdd(key, value);
            return key;
        }
    }
}
