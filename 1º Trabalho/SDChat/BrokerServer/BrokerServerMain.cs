﻿using BrokerImpl;
using CentralManagerInterface;
using System;
using System.Runtime.Remoting;

namespace BrokerServer
{
    class BrokerServerMain
    {
        private static readonly string CONFIG_FILE = "BrokerServer.exe.config";

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(CONFIG_FILE, false);
            var clients = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            if(clients.Length == 0)
            {
                Console.WriteLine("You must specify app.config file with wellknown tag inside a client tag.");
                Console.ReadLine();
                return;
            }
            
            var services = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            if (services.Length == 0)
            {
                Console.WriteLine("You must specify app.config file with wellknown tag inside a service tag.");
                Console.ReadLine();
                return;
            }

            var central = (ICentralManager) Activator.GetObject(clients[0].ObjectType, clients[0].ObjectUrl);
            var broker = new Broker(central);
            ObjRef objrefWellKnown = RemotingServices.Marshal(broker, services[0].ObjectUri);

            Console.WriteLine("Início do Server Broker.\n Espera de pedidos");
            Console.ReadLine();
        }
    }
}
