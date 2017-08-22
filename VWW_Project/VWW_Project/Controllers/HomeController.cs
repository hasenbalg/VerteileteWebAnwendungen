using DAL;
using Microsoft.AspNet.Identity;
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
            var events = this.eventsManager.GetAllEventsByUser(User.Identity.GetUserId()).ToList();
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
                    IsFullDay = ev.IsFullDay,
                    IsShared = ev.IsShared,
                    UserId = ev.UserId
                });
            }
            return new JsonResult { Data = eventsViewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        [HttpPost]
        public JsonResult SaveEvent(Event ev)
        {
            var status = false;
            if(ev.Id > 0)
            {
                Event updatedEvent = this.eventsManager.GetEventById(ev.Id);
                if(updatedEvent != null)
                {
                    updatedEvent.Subject = ev.Subject;
                    updatedEvent.Description = ev.Description;
                    updatedEvent.Start = ev.Start;
                    updatedEvent.End = ev.End;
                    updatedEvent.ThemeColor = ev.ThemeColor;
                    updatedEvent.IsFullDay = ev.IsFullDay;
                    updatedEvent.IsShared = ev.IsShared;

                    this.eventsManager.UpdateSet(updatedEvent);
                }
            }
            else
            {
                //ev.UserId = User.Identity.GetUserId();
                ev.UserId = "1";
                this.eventsManager.CreateEvent(ev);
            }
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;
            Event ev = this.eventsManager.GetEventById(id);
            if(ev != null)
            {
                this.eventsManager.DeleteEventById(id);
                status = true;
            }
            return new JsonResult{ Data = new {status = status}};
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}