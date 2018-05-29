using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Storages
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KV" in both code and config file together.
    public class KV : IKV
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
