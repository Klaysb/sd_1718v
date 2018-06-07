using System;
using System.ServiceModel;

namespace KVStorage
{
    [ServiceContract]
    public interface IKVService
    {
        [OperationContract]
        int GetCount();

        [OperationContract]
        int StoreData(string value);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        string RetrieveData(int key);

        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        void DeleteData(int key);
    }
}
