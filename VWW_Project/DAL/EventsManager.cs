using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventsManager
    {
        private readonly DbModelContainer db;

        public EventsManager(DbModelContainer db)
        {
            if (db == null)
            {
                throw new ArgumentNullException();
            }
            this.db = db;
        }

        public IQueryable<Event> GetAllEvents()
        {
            return db.EventSet;
        }

        public void CreateEvent(Event ev)
        {
            db.EventSet.Add(ev);
            db.SaveChanges();
        }

        public Event GetEventById(int id)
        {
            return db.EventSet.Find(id);
        }

        public void UpdateSet(Event ev)
        {
            db.Entry(ev).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteEventById(int id)
        {
            Event ev = GetEventById(id);
            if (ev == null)
            {
                throw new ArgumentException();
            }
            
            db.EventSet.Remove(ev);
            db.SaveChanges();
        }

    }
}
