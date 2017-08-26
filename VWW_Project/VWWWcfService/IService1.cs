using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VWWWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //User
        [OperationContract]
        UserData Login(UserData user);

        [OperationContract]
        List<UserData> GetAllUsers();

        [OperationContract]
        List<UserData> GetAllOnlineUsers();

        

        //Events
        [OperationContract]
        List<EventData> GetAllEvents(int me);

        [OperationContract]
        List<EventData> AddEvent(EventData newEvent);

        [OperationContract]
        bool EditEvent(EventData event2Edit);


        //Messages
        [OperationContract]
        List<MessageData> GetAllMessages(int fromUser, int toUser);

        [OperationContract]
        List<MessageData> SendMessage(MessageData msg);



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserData
    {

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastname { get; set; }

        [DataMember]
        public bool isOnline { get; set; }

        [DataMember]
        public string userName { get; set; }

        [DataMember]
        public string password { get; set; }

    }

    [DataContract]
    public class EventData
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string subject { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string location { get; set; }

        [DataMember]
        public DateTime start { get; set; }

        [DataMember]
        public DateTime end { get; set; }

        [DataMember]
        public string themeColor { get; set; }

        [DataMember]
        public bool isFullDay { get; set; }

        [DataMember]
        public bool isShared { get; set; }

        [DataMember]
        public int userId { get; set; }



    }

    [DataContract]
    public class MessageData
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public DateTime time { get; set; }

        [DataMember]
        public int FromUserId { get; set; }

        [DataMember]
        public int ToUserId { get; set; }

    }
}
