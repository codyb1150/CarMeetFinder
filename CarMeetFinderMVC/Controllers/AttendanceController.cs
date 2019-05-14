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

        // GET: Attendance/Create
        public ActionResult Create()
        {
            var service = CreateAttendanceService();

            ViewBag.CarID = new SelectList(service.GetCarSelectList(), "CarID", "DisplayMember");
            ViewBag.MeetID = new SelectList(service.GetMeetSelectList(), "MeetID", "LocationOfMeet");
            return View();
        }

        // POST: Attendance/Create
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


        // GET: Attendance/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateAttendanceService();
            var detail = service.GetAttendanceByID(id);
            var model = new AttendanceEdit
            {
                AttendanceID = detail.AttendanceID,
                CarID = detail.CarID,
                MeetID = detail.MeetID
            };

            ViewBag.CarID = new SelectList(service.GetCarSelectList(), "CarID", "DisplayMember");
            ViewBag.MeetID = new SelectList(service.GetMeetSelectList(), "MeetID", "LocationOfMeet");
            return View(model);
        }

        // POST: Attendance/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttendanceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AttendanceID != id)
            {
                ModelState.AddModelError("", "ID Is Mismatched");
                return View(model);
            }

            var service = CreateAttendanceService();

            if (service.UpdateAttendance(model))
            {
                TempData["SaveResult"] = "Your Attendance Was Updated!"; ;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Nothing Was Changed, Please Enter Your Changes.");
            return View(model);
        }

        // GET: Attendance/Details
        public ActionResult Details(int id)
        {
            var service = CreateAttendanceService();
            var model = service.GetAttendanceByID(id);
            return View(model);
        }

        // GET: Attendance/Delete
        public ActionResult Delete(int id)
        {
            var service = CreateAttendanceService();
            var model = service.GetAttendanceByID(id);

            return View(model);
        }

        // POST: Attendance/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var service = CreateAttendanceService();
            service.DeleteAttendance(id);
            TempData["SaveResult"] = "Your Attendance Was Deleted";

            return RedirectToAction("Index");
        }

        private AttendanceService CreateAttendanceService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AttendanceService(userID);
            return service;
        }
    }

}
