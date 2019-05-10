using CarMeetFinder.Data;
using CarMeetFinder.Models.AttendanceModels;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMeetFinderMVC.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AttendanceService(userID);
            var model = service.GetAttendance();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateAttendanceService();

            ViewBag.CarID = new SelectList(service.GetCarSelectList(), "CarID", "DisplayMember");
            ViewBag.MeetID = new SelectList(service.GetMeetSelectList(), "MeetID", "LocationOfMeet");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAttendanceService();

            if (service.CreateAttendance(model))
            {
                TempData["SaveResult"] = "Your Attendance Has Been Created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Attendance Could Not Be Created");
            return View(model);
        }
        private AttendanceService CreateAttendanceService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AttendanceService(userID);
            return service;
        }

        private MeetService CreateMeetService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MeetService(userID);
            return service;
        }
    }

}
