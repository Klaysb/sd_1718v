using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace HostBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service hosted. To close hosting, Press Enter.");
            Console.ReadLine();
        }
    }
}
