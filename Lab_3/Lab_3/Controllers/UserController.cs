using Lab_3.Data.Entities;
using Lab_3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_3.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View(NonPersistantDatabase.Users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if(ModelState.IsValid)
            {
                user.Id = NonPersistantDatabase.getNextId();
                NonPersistantDatabase.Users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            NonPersistantDatabase.RemoveUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(NonPersistantDatabase.FindUser(id));
        }


        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            return View(NonPersistantDatabase.FindUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                NonPersistantDatabase.RemoveUser(user.Id);
                user.Id = NonPersistantDatabase.getNextId();
                NonPersistantDatabase.Users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}