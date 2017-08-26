using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace VWWService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFService" in both code and config file together.
    public class WCFService : IWCFService
    {


        public List<User> GetAllUsers()
        {
            Console.WriteLine("Client will eine Liste aller BBenutzer haben");
            List<User> userList = new List<User>();

            // statt db
            userList.Add(new User() { FirstName = "Frank", LastName = "Hasenbalg", Username = "fr", IsOnline = true , Password = "huhu"});
            userList.Add(new User() { FirstName = "Pascal", LastName = "Wegner", Username = "pa", IsOnline = true, Password = "huhu" });
            userList.Add(new User() { FirstName = "Philipp", LastName = "Zylike", Username = "phi", IsOnline = false, Password = "huhu" });
            return userList;
        }

        public List<Message> GetMessages(User from, User to)
        {
            Console.WriteLine("Client will eine Liste aller nachichten von " + from.Username + " und " + to.Username);
            List<Message> messageList = new List<Message>();

            // statt db
            messageList.Add(new Message() { FromUserId = from.Id, ToUserId = to.Id, Text = "huhu", Time = DateTime.Now });
            messageList.Add(new Message() { FromUserId = to.Id, ToUserId = from.Id, Text = "haha", Time = DateTime.Now });
            messageList.Add(new Message() { FromUserId = from.Id, ToUserId = to.Id, Text = "hehe", Time = DateTime.Now });
            messageList.Add(new Message() { FromUserId = to.Id, ToUserId = from.Id, Text = "hoho", Time = DateTime.Now });
            messageList.Add(new Message() { FromUserId = from.Id, ToUserId = to.Id, Text = "hihi", Time = DateTime.Now });

            return messageList;
        }

        public List<Event> GetMyEvents(User me)
        {
            List<Event> eventList = new List<Event>();

            eventList.Add(new Event() { Subject = "Baden gehen", Description = "Wasser einlassen, baden, abtrocknen", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#f00" });
            eventList.Add(new Event() { Subject = "Duschen gehen", Description = "Fast wie baden, nur mit Wasser von oben", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#ff0" });
            eventList.Add(new Event() { Subject = "Zaehne putzen gehen", Description = "Fast wie Duschen, nur mit Zahnbuerste", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#f00" });
            eventList.Add(new Event() { Subject = "Fruehstuecken", Description = "fast wie  zaehneputzen, nur mit essen", Start = new DateTime(), End = new DateTime(), Location = "Kueche", IsFullDay = false, IsShared = true, ThemeColor = "#f00" });
            eventList.Add(new Event() { Subject = "nachhause gehen", Description = "den anderen Taetigkeiten unaehnlich", Start = new DateTime(), End = new DateTime(), Location = "Iregendwo", IsFullDay = false, IsShared = true, ThemeColor = "#f00" });

            return eventList;
        }

        public bool IsOn()
        {
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            List<User> usrLst = GetAllUsers();
            User me = usrLst.Where(u => u.Username == username && u.Password == password).First();
            return me != null;
        }
    }
}
