﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Broker.KVService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KVService.IKVService")]
    public interface IKVService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/GetCount", ReplyAction="http://tempuri.org/IKVService/GetCountResponse")]
        int GetCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/GetCount", ReplyAction="http://tempuri.org/IKVService/GetCountResponse")]
        System.Threading.Tasks.Task<int> GetCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/StoreData", ReplyAction="http://tempuri.org/IKVService/StoreDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IKVService/StoreDataArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        int StoreData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/StoreData", ReplyAction="http://tempuri.org/IKVService/StoreDataResponse")]
        System.Threading.Tasks.Task<int> StoreDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/RetrieveData", ReplyAction="http://tempuri.org/IKVService/RetrieveDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IKVService/RetrieveDataArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        string RetrieveData(int key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/RetrieveData", ReplyAction="http://tempuri.org/IKVService/RetrieveDataResponse")]
        System.Threading.Tasks.Task<string> RetrieveDataAsync(int key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/DeleteData", ReplyAction="http://tempuri.org/IKVService/DeleteDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IKVService/DeleteDataArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void DeleteData(int key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKVService/DeleteData", ReplyAction="http://tempuri.org/IKVService/DeleteDataResponse")]
        System.Threading.Tasks.Task DeleteDataAsync(int key);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKVServiceChannel : Broker.KVService.IKVService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KVServiceClient : System.ServiceModel.ClientBase<Broker.KVService.IKVService>, Broker.KVService.IKVService {
        
        public KVServiceClient() {
        }
        
        public KVServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KVServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KVServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KVServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetCount() {
            return base.Channel.GetCount();
        }
        
        public System.Threading.Tasks.Task<int> GetCountAsync() {
            return base.Channel.GetCountAsync();
        }
        
        public int StoreData(string value) {
            return base.Channel.StoreData(value);
        }
        
        public System.Threading.Tasks.Task<int> StoreDataAsync(string value) {
            return base.Channel.StoreDataAsync(value);
        }
        
        public string RetrieveData(int key) {
            return base.Channel.RetrieveData(key);
        }
        
        public System.Threading.Tasks.Task<string> RetrieveDataAsync(int key) {
            return base.Channel.RetrieveDataAsync(key);
        }
        
        public void DeleteData(int key) {
            base.Channel.DeleteData(key);
        }
        
        public System.Threading.Tasks.Task DeleteDataAsync(int key) {
            return base.Channel.DeleteDataAsync(key);
        }
    }
}
