using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    class ChatService : IChatService
    {
        Dictionary<IChatClient, string> _users = new Dictionary<IChatClient, string>();

        //User
        public bool LogIn(string userName, string password)
        {
            return GetAllUsers().Where(u => u.userName == userName && u.password == password).ToList().Count > 0;
        }

        public UserData GetUser(string userName)
        {
            return GetAllUsers().Where(u => u.userName == userName).First();
        }



        public void Join(string userName)
        {
            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            _users[connection] = userName;

            string user;
            if (!_users.TryGetValue(connection, out user))
            {
                return;
            }
            foreach (var other in _users.Keys)
            {
                if (other == connection)
                {
                    continue;
                }
                other.UpdateOnlineUsers();

            }
        }

        public void SendMessage(string message)
        {
            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            string user;
            if (!_users.TryGetValue(connection, out user))
            {
                return;
            }
            foreach (var other in _users.Keys)
            {
                //if (other == connection) {
                //    continue;
                //}
                other.RecieveMessage(user, message);
            }
        }

        public List<UserData> GetAllUsers()
        {
            List<UserData> userList = new List<UserData>();

            userList.Add(new UserData() { id = 1, firstName = "frank", lastName = "hasenbalg", userName = "fr", password = "huhu" });
            userList.Add(new UserData() { id = 2, firstName = "pascal", lastName = "wegner", userName = "pa", password = "huhu" });
            userList.Add(new UserData() { id = 3, firstName = "phillip", lastName = "zylike", userName = "phi", password = "huhu" });

            return userList;
        }

        public List<UserData> GetOnlineUsers()
        {
            List<UserData> uOnline = new List<UserData>();
            foreach (var _user in _users)
            {
                foreach (var userData in GetAllUsers())
                {
                    if (_user.Value.Equals(userData.userName))
                    {
                        uOnline.Add(userData);
                    }
                }
            }
            return uOnline;
        }

        public void AddUser(string userName, string password, string firstName, string lastname)
        {
            Console.Write("Implementier mich, wenn wir ne Datenbank haben.");
        }

        public void EditUser(string userName, string password, string firstName, string lastname, int id)
        {
            Console.Write("Implementier mich, wenn wir ne Datenbank haben.");
        }

        public void DeleteUser(int id)
        {
            Console.Write("Implementier mich, wenn wir ne Datenbank haben.");
        }

        public void AddEvent(string subject, string description, string location, DateTime start, bool isEntireDay, DateTime end, string color, bool isShared)
        {

            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            string user;
            if (!_users.TryGetValue(connection, out user))
            {
                return;
            }
            foreach (var other in _users.Keys)
            {
                other.UpdateCalendar();
            }
        }

        private List<EventData> GetAllEvents()
        {
            List<EventData> eventList = new List<EventData>();

            eventList.Add(new EventData() { subject = "Zaehne putzen", description = "Alle Zaehne werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 1 });
            eventList.Add(new EventData() { subject = "Pilze putzen", description = "Alle Pilze werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 2 });
            eventList.Add(new EventData() { subject = "Bude putzen", description = "Alle Bude werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 3 });
            eventList.Add(new EventData() { subject = "Schuhe putzen", description = "Alle Schuhe werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 4 });
            eventList.Add(new EventData() { subject = "Rest putzen", description = "Der ganze Scheiss wird geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 5 });

            return eventList.OrderBy(e => e.start).ToList();
        }

        public EventData GetEvent(int id)
        {
            return GetAllEvents().Where(e => e.id == id).First();
        }

        public List<EventData> GetEventsByUser(int userId)
        {
            return GetAllEvents().Where(e => e.userId == userId).ToList();
        }

        public void EditEvent(string subject, string description, string location, DateTime start, bool isEntireDay, DateTime end, string color, bool isShared, int id)
        {
            Console.Write("Implementier mich, wenn wir ne Datenbank haben.");
        }

        public void DeleteEvent(int id)
        {
            Console.Write("Implementier mich, wenn wir ne Datenbank haben.");
        }
    }
}
