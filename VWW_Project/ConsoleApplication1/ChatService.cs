using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        DbModelContainer db;
        UsersManager um;
        EventsManager em;




        public ChatService() {


             db = new DbModelContainer();
             um = new UsersManager(db);
             em = new EventsManager(db);


            //um.CreateUser(new User()
            //{
            //    FirstName = "andrej",
            //    LastName = "vasenko",
            //    Username = "an",
            //    Password = "huhu",
            //    IsOnline = true,
            //    Id = "11"

            //});

            //um.CreateUser(new User()
            //{
            //    FirstName = "marlenchen",
            //    LastName = "t",
            //    Username = "ma",
            //    Password = "huhu",
            //    IsOnline = true,
            //    Id = "12"

            //});

            //em.CreateEvent(new Event {
            //    Subject = "duschen",
            //    Description = "Wasser kommt von oben",
            //    Location = "Badezimmer",
            //    Start = DateTime.Now.AddHours(1),
            //    End = DateTime.Now.AddHours(2),
            //    IsFullDay = false,
            //    IsShared = true,
            //    ThemeColor = "#ff0",
            //    Id = 1,
            //    UserId = "10"
            //});

            //em.CreateEvent(new Event
            //{
            //    Subject = "essen",
            //    Description = "Nahreung aufnehmen",
            //    Location = "Kueche",
            //    Start = DateTime.Now.AddHours(3),
            //    End = DateTime.Now.AddHours(4),
            //    IsFullDay = false,
            //    IsShared = true,
            //    ThemeColor = "#f00",
            //    Id = 2,
            //    UserId = "11"
            //});

            //em.CreateEvent(new Event
            //{
            //    Subject = "kiffen",
            //    Description = "Joint rauchen",
            //    Location = "draussen",
            //    Start = DateTime.Now.AddHours(5),
            //    End = DateTime.Now.AddHours(6),
            //    IsFullDay = false,
            //    IsShared = true,
            //    ThemeColor = "#fff",
            //    Id = 3,
            //    UserId = "12"
            //});

        }

        //User
        public List<UserData> GetAllUsers()
        {
            List<UserData> userList = new List<UserData>();

            //userList.Add(new UserData() {  firstName = "frank", lastName = "hasenbalg", userName = "fr", password = "huhu" });
            //userList.Add(new UserData() {  firstName = "pascal", lastName = "wegner", userName = "pa", password = "huhu" });
            //userList.Add(new UserData() {  firstName = "phillip", lastName = "zylike", userName = "phi", password = "huhu" });

            foreach (var dbUser in um.GetAllUsers())
            {
                userList.Add(new UserData()
                {
                    firstName = dbUser.FirstName,
                    lastName = dbUser.LastName,
                    userName = dbUser.Username,
                    id = dbUser.Id,
                    password = dbUser.Password
                });
            }

            

            return userList;
        }

        public bool LogIn(string userName, string password)
        {
            return GetAllUsers()
                .Where(u => u.userName == userName && u.password == password).ToList().Count > 0;
        }

        public UserData GetUser(string userName)
        {
            return GetAllUsers().Where(u => u.userName == userName).First();
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
            string id = (Int32.Parse(um.GetAllUsers().OrderByDescending(u => u.Id).First().Id) + 1).ToString();
            um.CreateUser(new User()
            {
                FirstName = firstName,
                LastName = lastname,
                Password = password,
                Username = userName,
                Id = id
            });
        }

        public void EditUser(string userName, string password, string firstName, string lastname, string id)
        {
            DeleteUser(id);
            AddUser( userName,  password,  firstName,  lastname);
        }

        public void DeleteUser(string id)
        {
            um.DeleteUserById(id.ToString());
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

        public void LogOut() {
            IChatClient connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            _users.Remove(connection);

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


       

        public void AddEvent(string subject, string description, string location, DateTime start, bool isEntireDay, DateTime end, string color, bool isShared, string userId)
        {

            int id = em.GetAllEvents().OrderByDescending(e => e.Id).First().Id + 1;
            em.CreateEvent(new Event() {
                Subject = subject,
                Description = description,
                Location = location,
                Start = start,
                IsFullDay = isEntireDay,
                End = end,
                ThemeColor = color,
                IsShared = isShared,
                UserId = userId,
                Id = id
            });

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

            //eventList.Add(new EventData() { subject = "Zaehne putzen", description = "Alle Zaehne werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 1 });
            //eventList.Add(new EventData() { subject = "Pilze putzen", description = "Alle Pilze werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 2 });
            //eventList.Add(new EventData() { subject = "Bude putzen", description = "Alle Bude werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 3 });
            //eventList.Add(new EventData() { subject = "Schuhe putzen", description = "Alle Schuhe werden geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 4 });
            //eventList.Add(new EventData() { subject = "Rest putzen", description = "Der ganze Scheiss wird geputzt", start = DateTime.Now, end = DateTime.Now.AddHours(1), isEntireDay = false, color = "#f00", userId = 1, id = 5 });

            foreach (var dbEvent in em.GetAllEvents())
            {
                eventList.Add(new EventData()
                {
                    subject = dbEvent.Subject,
                    description = dbEvent.Description,
                    location = dbEvent.Location,
                    start = dbEvent.Start,
                    isEntireDay = dbEvent.IsFullDay,
                    end = dbEvent.End ?? DateTime.MinValue,
                    color = dbEvent.ThemeColor,
                    isShared = dbEvent.IsShared,
                    id = dbEvent.Id,
                    userId = dbEvent.UserId
                });
            }


            return eventList.OrderBy(e => e.start).ToList();
        }

        public EventData GetEvent(int id)
        {
            return GetAllEvents().Where(e => e.id == id).First();
        }

        public List<EventData> GetEventsByUser(string userId)
        {
            return GetAllEvents().Where(e => e.userId == userId || e.isShared).ToList();
        }

        public void EditEvent(string subject, string description, string location, DateTime start, bool isEntireDay, DateTime end, string color, bool isShared, int id, string userId)
        {
            DeleteEvent(id);
            AddEvent( subject,  description,  location,  start,  isEntireDay,  end,  color,  isShared, userId);
        }

        public void DeleteEvent(int id)
        {
            em.DeleteEventById(id);
        }
    }
}
