﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserData", Namespace="http://schemas.datacontract.org/2004/07/VWWWcfService")]
    [System.SerializableAttribute()]
    public partial class UserData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string firstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isOnlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string userNameField;
        
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
        public string firstName {
            get {
                return this.firstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstNameField, value) != true)) {
                    this.firstNameField = value;
                    this.RaisePropertyChanged("firstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isOnline {
            get {
                return this.isOnlineField;
            }
            set {
                if ((this.isOnlineField.Equals(value) != true)) {
                    this.isOnlineField = value;
                    this.RaisePropertyChanged("isOnline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastname {
            get {
                return this.lastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastnameField, value) != true)) {
                    this.lastnameField = value;
                    this.RaisePropertyChanged("lastname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                if ((object.ReferenceEquals(this.userNameField, value) != true)) {
                    this.userNameField = value;
                    this.RaisePropertyChanged("userName");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventData", Namespace="http://schemas.datacontract.org/2004/07/VWWWcfService")]
    [System.SerializableAttribute()]
    public partial class EventData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime endField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isFullDayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isSharedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string locationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime startField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string subjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string themeColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int userIdField;
        
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
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime end {
            get {
                return this.endField;
            }
            set {
                if ((this.endField.Equals(value) != true)) {
                    this.endField = value;
                    this.RaisePropertyChanged("end");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isFullDay {
            get {
                return this.isFullDayField;
            }
            set {
                if ((this.isFullDayField.Equals(value) != true)) {
                    this.isFullDayField = value;
                    this.RaisePropertyChanged("isFullDay");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isShared {
            get {
                return this.isSharedField;
            }
            set {
                if ((this.isSharedField.Equals(value) != true)) {
                    this.isSharedField = value;
                    this.RaisePropertyChanged("isShared");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string location {
            get {
                return this.locationField;
            }
            set {
                if ((object.ReferenceEquals(this.locationField, value) != true)) {
                    this.locationField = value;
                    this.RaisePropertyChanged("location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime start {
            get {
                return this.startField;
            }
            set {
                if ((this.startField.Equals(value) != true)) {
                    this.startField = value;
                    this.RaisePropertyChanged("start");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string subject {
            get {
                return this.subjectField;
            }
            set {
                if ((object.ReferenceEquals(this.subjectField, value) != true)) {
                    this.subjectField = value;
                    this.RaisePropertyChanged("subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string themeColor {
            get {
                return this.themeColorField;
            }
            set {
                if ((object.ReferenceEquals(this.themeColorField, value) != true)) {
                    this.themeColorField = value;
                    this.RaisePropertyChanged("themeColor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int userId {
            get {
                return this.userIdField;
            }
            set {
                if ((this.userIdField.Equals(value) != true)) {
                    this.userIdField = value;
                    this.RaisePropertyChanged("userId");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageData", Namespace="http://schemas.datacontract.org/2004/07/VWWWcfService")]
    [System.SerializableAttribute()]
    public partial class MessageData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FromUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ToUserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string textField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime timeField;
        
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
        public int FromUserId {
            get {
                return this.FromUserIdField;
            }
            set {
                if ((this.FromUserIdField.Equals(value) != true)) {
                    this.FromUserIdField = value;
                    this.RaisePropertyChanged("FromUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToUserId {
            get {
                return this.ToUserIdField;
            }
            set {
                if ((this.ToUserIdField.Equals(value) != true)) {
                    this.ToUserIdField = value;
                    this.RaisePropertyChanged("ToUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string text {
            get {
                return this.textField;
            }
            set {
                if ((object.ReferenceEquals(this.textField, value) != true)) {
                    this.textField = value;
                    this.RaisePropertyChanged("text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime time {
            get {
                return this.timeField;
            }
            set {
                if ((this.timeField.Equals(value) != true)) {
                    this.timeField = value;
                    this.RaisePropertyChanged("time");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        WpfApplication.ServiceReference1.UserData Login(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData> LoginAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllUsers", ReplyAction="http://tempuri.org/IService1/GetAllUsersResponse")]
        WpfApplication.ServiceReference1.UserData[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllUsers", ReplyAction="http://tempuri.org/IService1/GetAllUsersResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOnlineUsers", ReplyAction="http://tempuri.org/IService1/GetOnlineUsersResponse")]
        WpfApplication.ServiceReference1.UserData[] GetOnlineUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOnlineUsers", ReplyAction="http://tempuri.org/IService1/GetOnlineUsersResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData[]> GetOnlineUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllEvents", ReplyAction="http://tempuri.org/IService1/GetAllEventsResponse")]
        WpfApplication.ServiceReference1.EventData[] GetAllEvents(int me);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllEvents", ReplyAction="http://tempuri.org/IService1/GetAllEventsResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.EventData[]> GetAllEventsAsync(int me);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddEvent", ReplyAction="http://tempuri.org/IService1/AddEventResponse")]
        WpfApplication.ServiceReference1.EventData[] AddEvent(WpfApplication.ServiceReference1.EventData newEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddEvent", ReplyAction="http://tempuri.org/IService1/AddEventResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.EventData[]> AddEventAsync(WpfApplication.ServiceReference1.EventData newEvent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditEvent", ReplyAction="http://tempuri.org/IService1/EditEventResponse")]
        bool EditEvent(WpfApplication.ServiceReference1.EventData event2Edit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditEvent", ReplyAction="http://tempuri.org/IService1/EditEventResponse")]
        System.Threading.Tasks.Task<bool> EditEventAsync(WpfApplication.ServiceReference1.EventData event2Edit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMessages", ReplyAction="http://tempuri.org/IService1/GetAllMessagesResponse")]
        WpfApplication.ServiceReference1.MessageData[] GetAllMessages(int fromUser, int toUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMessages", ReplyAction="http://tempuri.org/IService1/GetAllMessagesResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.MessageData[]> GetAllMessagesAsync(int fromUser, int toUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMessage", ReplyAction="http://tempuri.org/IService1/SendMessageResponse")]
        WpfApplication.ServiceReference1.MessageData[] SendMessage(WpfApplication.ServiceReference1.MessageData msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMessage", ReplyAction="http://tempuri.org/IService1/SendMessageResponse")]
        System.Threading.Tasks.Task<WpfApplication.ServiceReference1.MessageData[]> SendMessageAsync(WpfApplication.ServiceReference1.MessageData msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WpfApplication.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WpfApplication.ServiceReference1.IService1>, WpfApplication.ServiceReference1.IService1 {
        
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
        
        public WpfApplication.ServiceReference1.UserData Login(string userName, string password) {
            return base.Channel.Login(userName, password);
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData> LoginAsync(string userName, string password) {
            return base.Channel.LoginAsync(userName, password);
        }
        
        public WpfApplication.ServiceReference1.UserData[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public WpfApplication.ServiceReference1.UserData[] GetOnlineUsers() {
            return base.Channel.GetOnlineUsers();
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.UserData[]> GetOnlineUsersAsync() {
            return base.Channel.GetOnlineUsersAsync();
        }
        
        public WpfApplication.ServiceReference1.EventData[] GetAllEvents(int me) {
            return base.Channel.GetAllEvents(me);
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.EventData[]> GetAllEventsAsync(int me) {
            return base.Channel.GetAllEventsAsync(me);
        }
        
        public WpfApplication.ServiceReference1.EventData[] AddEvent(WpfApplication.ServiceReference1.EventData newEvent) {
            return base.Channel.AddEvent(newEvent);
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.EventData[]> AddEventAsync(WpfApplication.ServiceReference1.EventData newEvent) {
            return base.Channel.AddEventAsync(newEvent);
        }
        
        public bool EditEvent(WpfApplication.ServiceReference1.EventData event2Edit) {
            return base.Channel.EditEvent(event2Edit);
        }
        
        public System.Threading.Tasks.Task<bool> EditEventAsync(WpfApplication.ServiceReference1.EventData event2Edit) {
            return base.Channel.EditEventAsync(event2Edit);
        }
        
        public WpfApplication.ServiceReference1.MessageData[] GetAllMessages(int fromUser, int toUser) {
            return base.Channel.GetAllMessages(fromUser, toUser);
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.MessageData[]> GetAllMessagesAsync(int fromUser, int toUser) {
            return base.Channel.GetAllMessagesAsync(fromUser, toUser);
        }
        
        public WpfApplication.ServiceReference1.MessageData[] SendMessage(WpfApplication.ServiceReference1.MessageData msg) {
            return base.Channel.SendMessage(msg);
        }
        
        public System.Threading.Tasks.Task<WpfApplication.ServiceReference1.MessageData[]> SendMessageAsync(WpfApplication.ServiceReference1.MessageData msg) {
            return base.Channel.SendMessageAsync(msg);
        }
    }
}
