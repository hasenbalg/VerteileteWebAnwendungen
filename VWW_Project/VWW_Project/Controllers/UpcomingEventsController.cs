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
    public class UpcomingEventsController : BaseDatabaseController
    {
        private EventsManager eventsManager;
        public UpcomingEventsController()
        {
            this.eventsManager = new EventsManager(this.Db);
        }
        // GET: Events
        public ActionResult Index()
        {
            List<Event> upcomingEvents = this.eventsManager.GetAllUpcomingEventsByUser(User.Identity.GetUserId()).ToList();
            return View(upcomingEvents);
        }
    }
}