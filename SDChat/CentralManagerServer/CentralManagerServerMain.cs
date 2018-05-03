using BrokerClientInterface;
using CentralManagerImpl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Remoting;

namespace CentralManagerServer
{
    class CentralManagerServerMain
    {
        private static readonly string CONFIG_FILE = "CentralManagerServer.exe.config";

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(CONFIG_FILE, false);
            var services = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            if (services.Length == 0)
            {
                Console.WriteLine("You must specify app.config file with wellknown tag inside a service tag.");
                Console.ReadLine();
                return;
            }
            var config = ConfigurationSettings.AppSettings;
            var type = config["type"];
            var assembly = config["assembly"];
            var brokers = new List<IBrokerClient>();
            for (int i = 2; i < config.Count; i++)
            {
                WellKnownClientTypeEntry entry = new WellKnownClientTypeEntry(type, assembly, config[i]);
                brokers.Add((IBrokerClient)Activator.GetObject(entry.ObjectType, entry.ObjectUrl));
            }
            var central = new CentralManager(brokers);
            ObjRef objrefWellKnown = RemotingServices.Marshal(central, services[0].ObjectUri);
            Console.WriteLine("Início do Server CentralManager.\n Espera de pedidos");
            Console.ReadLine();
        }
    }
}
