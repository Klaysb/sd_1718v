using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BrokerService;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            BrokerServiceClient cl = new BrokerServiceClient();
            var k1 = cl.StoreData("aha");
            var ob = cl.RetrieveData(k1);
            cl.DeleteData(k1);
            try
            {
                var ob2 = cl.RetrieveData(k1);
            }
            catch (Exception)
            {

            }
        }
    }
}
