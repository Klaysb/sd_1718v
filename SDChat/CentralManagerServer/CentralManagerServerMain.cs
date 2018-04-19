using System;
using System.Runtime.Remoting;

namespace CentralManagerServer
{
    class CentralManagerServerMain
    {
        private static readonly string CONFIG_FILE = "CentralManagerServer.exe.config";

        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(CONFIG_FILE, false);
            Console.WriteLine("Início do Server CentralManager.\n Espera de pedidos");
            Console.ReadLine();
        }
    }
}
