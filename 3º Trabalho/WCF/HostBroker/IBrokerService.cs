using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace HostBroker
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBrokerService" in both code and config file together.
    [ServiceContract]
    public interface IBrokerService
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        Key StoreData(object value);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        object RetrieveData(Key key);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        void DeleteData(Key key);
    }
}
