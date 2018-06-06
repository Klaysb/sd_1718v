using System;
using System.ServiceModel;

namespace Broker
{
    [ServiceContract]
    public interface IBrokerService
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        Key StoreData(string value);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        string RetrieveData(Key key);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        void DeleteData(Key key);
    }
}
