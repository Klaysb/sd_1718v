﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserApp.BrokerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Key", Namespace="http://schemas.datacontract.org/2004/07/Broker")]
    [System.SerializableAttribute()]
    public partial class Key : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] IndexesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] StoragesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] Indexes {
            get {
                return this.IndexesField;
            }
            set {
                if ((object.ReferenceEquals(this.IndexesField, value) != true)) {
                    this.IndexesField = value;
                    this.RaisePropertyChanged("Indexes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Storages {
            get {
                return this.StoragesField;
            }
            set {
                if ((object.ReferenceEquals(this.StoragesField, value) != true)) {
                    this.StoragesField = value;
                    this.RaisePropertyChanged("Storages");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BrokerService.IBrokerService")]
    public interface IBrokerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/StoreData", ReplyAction="http://tempuri.org/IBrokerService/StoreDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.InvalidOperationException), Action="http://tempuri.org/IBrokerService/StoreDataInvalidOperationExceptionFault", Name="InvalidOperationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        UserApp.BrokerService.Key StoreData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/StoreData", ReplyAction="http://tempuri.org/IBrokerService/StoreDataResponse")]
        System.Threading.Tasks.Task<UserApp.BrokerService.Key> StoreDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/RetrieveData", ReplyAction="http://tempuri.org/IBrokerService/RetrieveDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IBrokerService/RetrieveDataArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        string RetrieveData(UserApp.BrokerService.Key key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/RetrieveData", ReplyAction="http://tempuri.org/IBrokerService/RetrieveDataResponse")]
        System.Threading.Tasks.Task<string> RetrieveDataAsync(UserApp.BrokerService.Key key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/DeleteData", ReplyAction="http://tempuri.org/IBrokerService/DeleteDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentException), Action="http://tempuri.org/IBrokerService/DeleteDataArgumentExceptionFault", Name="ArgumentException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void DeleteData(UserApp.BrokerService.Key key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrokerService/DeleteData", ReplyAction="http://tempuri.org/IBrokerService/DeleteDataResponse")]
        System.Threading.Tasks.Task DeleteDataAsync(UserApp.BrokerService.Key key);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBrokerServiceChannel : UserApp.BrokerService.IBrokerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BrokerServiceClient : System.ServiceModel.ClientBase<UserApp.BrokerService.IBrokerService>, UserApp.BrokerService.IBrokerService {
        
        public BrokerServiceClient() {
        }
        
        public BrokerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BrokerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrokerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrokerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UserApp.BrokerService.Key StoreData(string value) {
            return base.Channel.StoreData(value);
        }
        
        public System.Threading.Tasks.Task<UserApp.BrokerService.Key> StoreDataAsync(string value) {
            return base.Channel.StoreDataAsync(value);
        }
        
        public string RetrieveData(UserApp.BrokerService.Key key) {
            return base.Channel.RetrieveData(key);
        }
        
        public System.Threading.Tasks.Task<string> RetrieveDataAsync(UserApp.BrokerService.Key key) {
            return base.Channel.RetrieveDataAsync(key);
        }
        
        public void DeleteData(UserApp.BrokerService.Key key) {
            base.Channel.DeleteData(key);
        }
        
        public System.Threading.Tasks.Task DeleteDataAsync(UserApp.BrokerService.Key key) {
            return base.Channel.DeleteDataAsync(key);
        }
    }
}
