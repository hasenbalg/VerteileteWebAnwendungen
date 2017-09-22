using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    [ServiceContract(CallbackContract = typeof(IChatClient))]
    interface IChatService
    {

        //User
        [OperationContract]
        bool LogIn(string userName, string password);

        [OperationContract]
        void LogOut();

        [OperationContract]
        UserData GetUser(string userName);

        [OperationContract]
        List<UserData> GetAllUsers();

        [OperationContract]
        List<UserData> GetOnlineUsers();

        [OperationContract(IsOneWay = true)]
        void AddUser(string userName, string password, string firstName, string lastname);

        [OperationContract(IsOneWay = true)]
        void EditUser(string userName, string password, string firstName, string lastname, string id);

        [OperationContract(IsOneWay = true)]
        void DeleteUser(string id);


        //Event
        [OperationContract(IsOneWay = true)]
        void AddEvent(string subject,
            string description,
           // string location,
            DateTime start,
            bool isEntireDay,
            DateTime end,
            string color,
            bool isShared,
            string userId);

        [OperationContract]
        EventData GetEvent(int id);

        [OperationContract]
        List<EventData> GetEventsByUser(string userId);

        [OperationContract(IsOneWay = true)]
        void EditEvent(string subject,
            string description,
            //string location,
            DateTime start,
            bool isEntireDay,
            DateTime end,
            string color,
            bool isShared,
            int id,
            string userId);

        [OperationContract(IsOneWay = true)]
        void DeleteEvent(int id);

        //Chat
        [OperationContract(IsOneWay = true)]
        void Join(string userName);


        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    [DataContract]
    public class UserData
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string userName { get; set; }

        [DataMember]
        public string password { get; set; }
    }

    [DataContract]
    public class EventData
    {
        [DataMember]
        public string subject { get; set; }

        [DataMember]
        public string description { get; set; }

        //[DataMember]
        //public string location { get; set; }

        [DataMember]
        public DateTime start { get; set; }

        [DataMember]
        public bool isEntireDay { get; set; }

        [DataMember]
        public DateTime end { get; set; }

        [DataMember]
        public string color { get; set; }

        [DataMember]
        public bool isShared { get; set; }

        [DataMember]
        public string userId { get; set; }

        [DataMember]
        public int id { get; set; }

    }
}
