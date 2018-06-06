using System;
using System.ServiceModel;

namespace KVStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(KVService)))
            {
                host.Open();
                Console.WriteLine("Storage service started at {0}.", host.BaseAddresses[0]);
                Console.ReadLine();
            }
        }
    }
}
