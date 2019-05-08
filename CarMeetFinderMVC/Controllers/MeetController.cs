using CarMeetFinder.Data;
using CarMeetFinder.Models.MeetModels;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMeetFinderMVC.Controllers
{
    public class MeetController : Controller
    {
        // GET: Meet
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MeetService(userID);
            var model = service.GetMeets();
            return View(model);
        }

        // GET: Meet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMeetService();

            if(service.CreateMeet(model))
            {
                TempData["SaveResult"] = "Your Meet Has Successfully Been Created!";
                return RedirectToAction("Index"); 
            }

            ModelState.AddModelError("", "Meet Could Not Be Made");
            return View(model);
        }

        // GET: Meet/Details
        public ActionResult Details(int id)
        {
            var service = CreateMeetService();
            var model = service.GetMeetByID(id);
            return View(model);
        }

        // GET: Meet/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMeetService();
            var detail = service.GetMeetByID(id);
            var model = new MeetEdit
            {
                MeetID = detail.MeetID,
                LocationOfMeet = detail.LocationOfMeet,
                DescriptionOfMeet = detail.DescriptionOfMeet,
                DateOfMeet = detail.DateOfMeet
            };
            return View(model);
        }
        // POST: Meet/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MeetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MeetID != id)
            {
                ModelState.AddModelError("","The ID's Do No Match");
                return View(model);
            }

            var service = CreateMeetService();

            if (service.UpdateMeet(model))
            {
                TempData["SaveResult"] = "Your Meet Was Updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Nothing Was Changed, Please Enter Your Changes.");
            return View(model);
        }

        // GET: Meet/Delete
        public ActionResult Delete(int id)
        {
            var service = CreateMeetService();
            var model = service.GetMeetByID(id);

            return View(model);
        }
        
        // POST: Meet/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var service = CreateMeetService();
            service.DeleteMeet(id);

            TempData["SaveResult"] = "Your Meet Was Deleted.";
            return RedirectToAction("Index");
        }

        public MeetService CreateMeetService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MeetService(userID);
            return service;
        }
    }
}