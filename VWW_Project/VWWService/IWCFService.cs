using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace VWWService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFService" in both code and config file together.
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        bool IsOn();
        List<User> GetAllUsers();
        List<Message> GetMessages(User from, User to);
        List<Event> GetMyEvents(User me);

        bool LoginUser(string username, string password);
    }

    [DataContract]
    public class UserData {
        [DataMember]
        public int id { get; set; }
        public String username { get; set; }
        public bool isOnline { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
    }

    
}
