using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersManager
    {
        private readonly DbModelContainer db;

        public UsersManager(DbModelContainer db)
        {
            if (db == null)
            {
                throw new ArgumentNullException();
            }
            this.db = db;
        }

        public IQueryable<User> GetAllUsers()
        {
            return db.UserSet.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
        }

        public void CreateUser(User user)
        {
            db.UserSet.Add(user);
            db.SaveChanges();
        }

        public User GetUserById(string id)
        {
            return db.UserSet.Find(id);
        }

        public void UpdateSet(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteUserById(string id)
        {
            User user = GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            db.UserSet.Remove(user);
            db.SaveChanges();
        }

        public void SetUserOnline(string id)
        {
            User user = GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            user.IsOnline = true;
            UpdateSet(user);
        }
        public void SetUserOffline(string id)
        {
            User user = GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            user.IsOnline = false;
            UpdateSet(user);
        }
    }
}
