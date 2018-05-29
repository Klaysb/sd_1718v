using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Brokers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBrokerService" in both code and config file together.
    [ServiceContract]
    public interface IBrokerService
    {
        [OperationContract]
        int StoreData(string value);

        [OperationContract]
        string RetrieveData(int key);

        [OperationContract]
        void DeleteData(int key);
    }
}
