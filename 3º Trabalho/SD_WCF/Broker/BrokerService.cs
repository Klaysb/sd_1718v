using Broker.KVService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Broker
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class BrokerService : IBrokerService
    {
        private static readonly int MAX_SAVES = 2;
        private List<KVServiceClient> storages = new List<KVServiceClient>();

        public BrokerService()
        {
            var serviceModel = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
            foreach (ChannelEndpointElement a in serviceModel.Client.Endpoints)
            {
                storages.Add(new KVServiceClient(a.Name, a.Address.ToString()));
            }
        }

        public void DeleteData(Key key)
        {
            CheckKey(key);
            var wasDeleted = false;

            for (int i = 0; i < key.Storages.Count; i++)
            {
                var st = key.Storages[i];
                var kv = GetStorage(st);

                try
                {
                    kv.DeleteData(key.Indexes[i]);
                    wasDeleted = true;
                }
                catch (Exception)
                {
                    // TODO ???
                }
            }

            if (!wasDeleted)
            {
                throw new FaultException<ArgumentException>(
                    new ArgumentException("Value cannot be deleted."),
                    new FaultReason("Value cannot be deleted.")
                );
            }
        }

        public string RetrieveData(Key key)
        {
            CheckKey(key);
            for (int i = 0; i < key.Storages.Count; i++)
            {
                var st = key.Storages[i];
                var kv = GetStorage(st);
                try
                {
                    return kv.RetrieveData(key.Indexes[i]);
                }
                catch (Exception)
                {
                    // TODO ???
                }
            }
            throw new FaultException<ArgumentException>(
                new ArgumentException("Value not found."),
                new FaultReason("Value not found.")
            );
        }

        public Key StoreData(string value)
        {
            Key key = new Key();

            // Determine storage capacity
            List<Tuple<int, KVServiceClient>> counter = new List<Tuple<int, KVServiceClient>>();
            foreach (var storage in storages)
            {
                try
                {
                    int count = storage.GetCount();
                    counter.Add(new Tuple<int, KVServiceClient>(count, storage));
                }
                catch (Exception ex)
                {
                    // Storage not available.
                }
            }

            // orders by storage size ascending
            counter.OrderBy(t => t.Item1);
            if (counter.Count < MAX_SAVES)
            {
                throw new FaultException<InvalidOperationException>(
                    new InvalidOperationException("Could not save the value."),
                    new FaultReason("Could not save the value.")
                );
            }
            int saved = 0;
            foreach(var tuple in counter)
            {
                try
                {
                    var storage = tuple.Item2;
                    int index = storage.StoreData(value);
                    key.Indexes.Add(index);
                    key.Storages.Add(storage.Endpoint.Address.ToString());
                    saved++;
                }
                catch (Exception)
                {

                }
                if (saved == MAX_SAVES) break;
            }
            if (saved != MAX_SAVES)
            {
                throw new FaultException<InvalidOperationException>(
                    new InvalidOperationException("Could not save the value."),
                    new FaultReason("Could not save the value.")
                );
            }
            return key;
        }

        private void CheckKey(Key key)
        {
            if (key == null)
            {
                throw new FaultException<ArgumentException>(
                    new ArgumentException("Key cannot be null."),
                    new FaultReason("Key cannot be null.")
                );
            }
        }

        private KVServiceClient GetStorage(string address)
        {
            return storages.Where(s => s.Endpoint.Address.ToString().Equals(address)).FirstOrDefault();
        }
    }
}
