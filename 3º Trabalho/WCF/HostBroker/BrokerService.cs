﻿using HostBroker.KVService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace HostBroker
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

        public object RetrieveData(Key key)
        {
            CheckKey(key);
            for (int i = 0; i < key.Storages.Count; i++)
            {
                var st = key.Storages[i];
                var kv = GetStorage(st);

                try
                {
                    var xml = kv.RetrieveData(key.Indexes[i]);
                    return XmlToObject(xml);
                }
                catch (Exception)
                {
                    // TODO ???
                }
            }
            throw new ArgumentException("Value not found.");
        }

        public Key StoreData(object value)
        {
            Key key = new Key();
            string xml = ObjectToXml(value);

            foreach (var storage in storages)
            {
                // TODO ALGORITMO E LOCALIZAÇÃO
                try
                {
                    int index = storage.StoreData(xml);
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

        private static string ObjectToXml(object value)
        {
            var xmlSerializer = new XmlSerializer(typeof(object));
            var xml = "";

            using (var sw = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(sw))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    xml = sw.ToString();
                }
            }
            return xml;
        }

        private static object XmlToObject(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(object));
            using(var reader = new StringReader(xml))
            {
                return xmlSerializer.Deserialize(reader);
            }
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
