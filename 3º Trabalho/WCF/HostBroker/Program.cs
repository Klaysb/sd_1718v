using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace HostBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BrokerService)))
            {
                host.Open();
                Console.WriteLine("Broker service started at {0}.", host.BaseAddresses[0]);
                Console.ReadLine();
            }
        }
    }
}
