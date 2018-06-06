using Broker.KVService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Broker
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class BrokerService : IBrokerService
    {
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

            if (!wasDeleted) throw new ArgumentException("Value cannot be deleted.");
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
            throw new ArgumentException("Value not found.");
        }

        public Key StoreData(string value)
        {
            Key key = new Key();
            foreach (var storage in storages)
            {
                // TODO ALGORITMO E LOCALIZAÇÃO
                try
                {
                    int index = storage.StoreData(value);
                    key.Indexes.Add(index);
                    key.Storages.Add(storage.Endpoint.Address.ToString());
                }
                catch (Exception)
                {
                    // Nothing to do
                }


            }
            return key;
        }

        private void CheckKey(Key key)
        {
            if (key == null) throw new ArgumentException("Key cannot be null.");
        }

        private KVServiceClient GetStorage(string address)
        {
            return storages.Where(s => s.Endpoint.Address.ToString().Equals(address)).FirstOrDefault();
        }
    }
}
