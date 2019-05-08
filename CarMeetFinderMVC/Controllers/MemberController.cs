using CarMeetFinder.Models.MemberModels;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMeetFinderMVC.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userID);
            var model = service.GetMembers();
            return View(model);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMemberService();

            if (service.CreateMember(model))
            {
                TempData["SaveResult"] = "Member Added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Member Could Not Be Made");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateMemberService();
            var model = service.GetMemberByID(id);

            return View(model);
        }

        // GET: Member/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMemberService();
            var detail = service.GetMemberByID(id);
            var model = new MemberEdit
            {
                MemberID = detail.MemberID,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Location = detail.Location,
                FullName = $"{detail.FirstName} {detail.LastName}"

            };
            return View(model);
        }

        // POST: Member/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MemberEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MemberID != id)
            {
                ModelState.AddModelError("", "Member ID's Do Not Match");
                return View(model);
            }

            var service = CreateMemberService();

            if (service.UpdateMember(model))
            {
                TempData["SaveResult"] = "Your Profile Has Been Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Nothing Was Changed, Please Enter Your Changes.");
            return View(model);
        }

        // GET: Car/Delete
        public ActionResult Delete(int id)
        {
            var service = CreateMemberService();
            var model = service.GetMemberByID(id);

            return View(model);
        }

        // POST: Car/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var service = CreateMemberService();

            service.DeleteMember(id);

            TempData["SaveResult"] = "This Profile Has Been Deleted.";

            return RedirectToAction("Index");
        }

        public MemberService CreateMemberService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userID);
            return service;
        }
    }
}