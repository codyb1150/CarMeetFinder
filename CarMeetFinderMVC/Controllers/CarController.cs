using CarMeetFinder.Data;
using CarMeetFinder.Models;
using CarMeetFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarMeetFinderMVC.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        // GET: Car
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userID);
            var model = service.GetCars();
            return View(model);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCarService();

            if (service.CreateCar(model))
            {
                TempData["SaveResult"] = "Your Car Was Created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Car Could Not Be Created.");

            return View(model);
        }

        // GET: Car/Details
        public ActionResult Details(int id)
        {
            var service = CreateCarService();
            var model = service.GetCarByID(id);
            return View(model);
        }

        // GET: Car/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCarService();
            var detail = service.GetCarByID(id);
            var model = new CarEdit
            {
                CarID = detail.CarID,
                Make = detail.Make,
                VehicleModel = detail.VehicleModel,
                Specifications = detail.Specifications,
                Description = detail.Description
            };
            return View(model);

        }

        // POST: Car/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CarID != id)
            {
                ModelState.AddModelError("", "ID Is Mismatched");
                return View(model);
            }

            var service = CreateCarService();

            if (service.UpdateCar(model))
            {
                TempData["SaveResult"] = "Your Car Was Updated!"; ;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Nothing Was Changed, Please Enter Your Changes.");
            return View(model);
        }

        // GET: Car/Delete
        public ActionResult Delete(int id)
        {
            var service = CreateCarService();
            var model = service.GetCarByID(id);

            return View(model);
        }

        // POST: Car/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var service = CreateCarService();
            service.DeleteCar(id);
            TempData["SaveResult"] = "Your Car Was Deleted.";

            return RedirectToAction("Index");
        }

        private CarService CreateCarService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userID);
            return service;
        }
    }
}