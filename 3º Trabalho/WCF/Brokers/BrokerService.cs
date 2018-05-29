using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Brokers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BrokerService" in both code and config file together.
    public class BrokerService : IBrokerService
    {
        public void DeleteData(int key)
        {
            throw new NotImplementedException();
        }

        public string RetrieveData(int key)
        {
            throw new NotImplementedException();
        }

        public int StoreData(string value)
        {
            throw new NotImplementedException();
        }
    }
}
