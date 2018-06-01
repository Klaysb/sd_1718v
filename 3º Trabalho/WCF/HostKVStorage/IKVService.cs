using System;
using System.ServiceModel;

namespace HostKVStorage
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKVService" in both code and config file together.
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
