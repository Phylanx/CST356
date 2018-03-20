using Final.Web.Models.Entities;
using Final.Web.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _service;
        public CarController(ICarService serv)
        {
            _service = serv;
        }



        public ActionResult CarIndex()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View(_service.GetUserCars(ViewBag.UserId));
        }



        [HttpGet]
        public ActionResult CarCreate()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }
        [HttpPost]
        public ActionResult CarCreate(CarModel car)
        {
            ViewBag.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _service.CreateCar(car);
                return RedirectToAction("CarIndex");
            }
            return View();
        }



        [HttpGet]
        public ActionResult CarUpdate(String id)
        {
            return View(_service.GetCar(id));
        }
        [HttpPost]
        public ActionResult CarUpdate(CarModel car)
        {
            if(ModelState.IsValid)
            {
                _service.UpdateCar(car);
                return RedirectToAction("CarIndex");
            }
            return View();
        }



        public ActionResult CarDelete(String id)
        {
            _service.DeleteCar(id);
            return RedirectToAction("CarIndex");
        }



        [HttpGet]
        public ActionResult CarInfo(String id)
        {
            return View(_service.GetCar(id));
        }


    }
}