using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VWWWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //User
        public List<UserData> GetAllUsers()
        {
            List<UserData> userList = new List<UserData>();

            userList.Add(new UserData() { id = 1, firstName = "frank", lastname = "hasenbalg", isOnline = true, userName = "fr" });
            userList.Add(new UserData() { id = 2, firstName = "pascal", lastname = "wegner", isOnline = true, userName = "pa" });
            userList.Add(new UserData() { id = 3, firstName = "phillip", lastname = "zylike", isOnline = true, userName = "phi" });

            return userList;
        }

        public List<UserData> GetOnlineUsers()
        {
            return GetAllUsers().Where(u => u.isOnline == true).ToList();
        }

        public UserData Login(string userName, string password)
        {

            //GetAllUsers().Where(u => u.userName == userName && u.password == password).First();
            return GetAllUsers().Where(u => u.userName == userName).First();
        }


        //Event
        public List<EventData> GetAllEvents(int meId)
        {
            Console.WriteLine("schicke alle events von "  + meId);
            List<EventData> eventList = new List<EventData>();

            eventList.Add(new EventData() {subject = "Zaehne putzen", description = "Alle Zaehne werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isFullDay = false, themeColor = "#f00", userId = 1, id = 1 });
            eventList.Add(new EventData() {subject = "Pilze putzen", description = "Alle Pilze werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isFullDay = false, themeColor = "#f00", userId = 1, id = 2 });
            eventList.Add(new EventData() {subject = "Bude putzen", description = "Alle Bude werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isFullDay = false, themeColor = "#f00", userId = 1, id = 3 });
            eventList.Add(new EventData() {subject = "Schuhe putzen", description = "Alle Schuhe werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isFullDay = false, themeColor = "#f00", userId = 1, id = 4 });
            eventList.Add(new EventData() {subject = "Rest putzen", description = "Der ganze Scheiss wird geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isFullDay = false, themeColor = "#f00", userId = 1, id = 5 });

            return eventList.Where(e => e.userId == meId).OrderBy(e => e.start).ToList();
        }

        public List<EventData> AddEvent(EventData newEvent)
        {
            List<EventData> eventList = GetAllEvents(newEvent.userId);
            eventList.Add(newEvent);
            Console.WriteLine(eventList.Count);
            return eventList;
        }

        public bool EditEvent(EventData event2Edit)
        {

            Console.WriteLine("new Event should be added");
            return true;
        }


        //Messages
        public List<MessageData> GetAllMessages(int meId, int otherId)
        {
            List<MessageData> messageList = new List<MessageData>();

            messageList.Add(new MessageData() {text = "huhu", time = DateTime.Now, FromUserId = 1, ToUserId = 2 });
            messageList.Add(new MessageData() {text = "haha", time = DateTime.Now, FromUserId = 2, ToUserId = 2 });
            messageList.Add(new MessageData() {text = "hehe", time = DateTime.Now, FromUserId = 1, ToUserId = 3 });
            messageList.Add(new MessageData() {text = "hihi", time = DateTime.Now, FromUserId = 1, ToUserId = 3 });
            messageList.Add(new MessageData() {text = "hoho", time = DateTime.Now, FromUserId = 1, ToUserId = 3 });
            messageList.Add(new MessageData() {text = "hyhy", time = DateTime.Now, FromUserId = 2, ToUserId = 1 });
            messageList.Add(new MessageData() {text = "chch", time = DateTime.Now, FromUserId = 3, ToUserId = 2 });

            return messageList.Where(m => m.ToUserId == meId || m.FromUserId == otherId).OrderBy(m => m.time).ToList();
        }

        public List<MessageData> SendMessage(MessageData msg)
        {
            List<MessageData> messageList = GetAllMessages(msg.FromUserId, msg.ToUserId);
            messageList.Add(msg);
            return messageList;
        }

        
    }
}
