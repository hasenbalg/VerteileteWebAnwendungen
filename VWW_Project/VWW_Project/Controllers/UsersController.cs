using DAL;
using Microsoft.AspNet.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VWW_Project.Controllers
{
    [Authorize]
    public class UsersController : BaseDatabaseController
    {
        private UsersManager usersManager;
        public UsersController()
        {
            this.usersManager = new UsersManager(this.Db);
        }
        // GET: Users
        public ActionResult Index()
        {
            // we don't want to show ourself in our list
            List<User> toExcept = new List<User>();
            toExcept.Add(this.usersManager.GetUserById(User.Identity.GetUserId()));

            return View(this.usersManager.GetAllUsers().ToList().Except(toExcept));
        }
    }
}