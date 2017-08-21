using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VWW_Project.Models;

namespace VWW_Project.Controllers
{
    public class HomeController : BaseDatabaseController
    {
        private EventsManager eventsManager;
        public HomeController()
        {
            this.eventsManager = new EventsManager(this.Db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = this.eventsManager.GetAllEvents().ToList();
            // need to map every entity event to a copy because otherwise json can't serialize properly and ends in circular reference
            var eventsViewModel = new List<Event>();
            foreach(var ev in events)
            {
                eventsViewModel.Add(new Event()
                {
                    Id = ev.Id,
                    Subject = ev.Subject,
                    Description = ev.Description,
                    Start = ev.Start,
                    End = ev.End,
                    ThemeColor = ev.ThemeColor,
                    IsFullDay = ev.IsFullDay
                });
            }
            return new JsonResult { Data = eventsViewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}