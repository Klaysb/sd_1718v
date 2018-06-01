using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HostBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri addr1 = new Uri("http://localhost:8080/svc2");
            Type svcType = typeof(BrokerService);
            //BasicHttpBinding bind = new BasicHttpBinding();
            WSDualHttpBinding bind = new WSDualHttpBinding();
            ServiceHost svcHost = new ServiceHost(svcType);

            ServiceMetadataBehavior smb = svcHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

            if (smb != null)
            {
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = addr1;
            }
            else
            {
                smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = addr1
                };
                svcHost.Description.Behaviors.Add(smb);
            }

            svcHost.AddServiceEndpoint(typeof(IBrokerService), bind, addr1);
            svcHost.Open();
            Console.WriteLine("Service hosted. To close hosting, Press Enter.");
            Console.ReadLine();
        }
    }
}
