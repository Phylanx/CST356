using Lab5_v3.Data;
using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using Lab5_v3.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5_v3.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _serv;
        private readonly ILog _log = log4net.LogManager.GetLogger(typeof(UserController));

        public UserController(IUserService service) { _serv = service; }
        public ActionResult Index()
        {
            _log.Debug("Getting list of users");
            ViewBag.AverageFingerCount = _serv.GetAverageFingers();
            return View(_serv.GetAllUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                _serv.SaveUser(userModel);
                _log.Debug("User saved");
                return RedirectToAction("Index");
            }
            else
            {
                _log.Error("Failed to create User");
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(_serv.GetUser(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_serv.GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                _serv.UpdateUser(userModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _serv.DeleteUser(id);
            return RedirectToAction("Index");
        }

        
    }
}