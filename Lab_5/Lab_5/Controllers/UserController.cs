using Lab_5.Data;
using Lab_5.Data.Entities;
using Lab_5.Models;
using Lab_5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_5.Controllers
{
    public class UserController : Controller
    {
        private IDataService Service { get; set;}
        
        public UserController(IDataService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(Service.GetAllUsers());
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
                Service.SaveUser(Service.ToUser(userModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(Service.GetUser(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Service.GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                Service.Update(userModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Service.DeleteUser(id);
            return RedirectToAction("Index");
        }


    }
}