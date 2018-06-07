using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using System.Threading;

namespace KVStorage
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class KVService : IKVService
    {
        private readonly ConcurrentDictionary<int, string> values = new ConcurrentDictionary<int, string>();
        private volatile int counter = -1;

        public int GetCount()
        {
            return values.Count;
        }

        public void DeleteData(int key)
        {
            if (!values.TryRemove(key, out string value))
            {
                throw new FaultException<ArgumentException>(
                    new ArgumentException("Key not found."),
                    new FaultReason("Key not found.")
                );
            }
        }

        public string RetrieveData(int key)
        {
            if (!values.TryGetValue(key, out string value))
            {
                throw new FaultException<ArgumentException>(
                    new ArgumentException("Key not found."),
                    new FaultReason("Key not found.")
                );
            }
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
