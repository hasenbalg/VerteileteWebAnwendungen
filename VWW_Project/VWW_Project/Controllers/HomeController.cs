using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VWW_Project.Models;

namespace VWW_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Calender()
        {
            ViewBag.Message = "Calender";
            ViewBag.Days = new Date().getAllDatesOfYear(DateTime.Today.Year);
            return View();
        }
        public ActionResult Schedule()
        {
            ViewBag.Message = "Calender";

            return View();
        }
        public ActionResult OtherUser()
        {
            ViewBag.Message = "Calender";

            return View();
        }
    }
}