using System;
using System.ServiceModel;

namespace HostKVStorage
{
    [ServiceContract]
    public interface IKVService
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        int StoreData(string value);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        string RetrieveData(int key);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        void DeleteData(int key);
    }
}
