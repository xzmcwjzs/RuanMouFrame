﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04_SOA.UnitTest.xzmcwjzs.ntu.wcf {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/_04_SOA.WCF.Application")]
    [System.SerializableAttribute()]
    public partial class Student : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="xzmcwjzs.ntu.wcf.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HelloWorld", ReplyAction="http://tempuri.org/IService1/HelloWorldResponse")]
        string HelloWorld(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HelloWorld", ReplyAction="http://tempuri.org/IService1/HelloWorldResponse")]
        System.Threading.Tasks.Task<string> HelloWorldAsync(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        _04_SOA.UnitTest.xzmcwjzs.ntu.wcf.Student GetUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<_04_SOA.UnitTest.xzmcwjzs.ntu.wcf.Student> GetUserAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : _04_SOA.UnitTest.xzmcwjzs.ntu.wcf.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<_04_SOA.UnitTest.xzmcwjzs.ntu.wcf.IService1>, _04_SOA.UnitTest.xzmcwjzs.ntu.wcf.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld(int num) {
            return base.Channel.HelloWorld(num);
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync(int num) {
            return base.Channel.HelloWorldAsync(num);
        }
        
        public _04_SOA.UnitTest.xzmcwjzs.ntu.wcf.Student GetUser() {
            return base.Channel.GetUser();
        }
        
        public System.Threading.Tasks.Task<_04_SOA.UnitTest.xzmcwjzs.ntu.wcf.Student> GetUserAsync() {
            return base.Channel.GetUserAsync();
        }
    }
}