using System;
using System.ServiceModel;

namespace HostBroker
{
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
