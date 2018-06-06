using System;
using System.ServiceModel;

namespace Broker
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
