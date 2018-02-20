using Lab_5.Data;
using Lab_5.Data.Entities;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_5.Controllers
{
    public class UserController : Controller
    {
        private Repository DbService { get; set;}

        public UserController()
        {
            DbService = new Repository(new AppDbContext());
        }

        UserController(Repository repository)
        {
            DbService = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(DbService.GetAllUsers());
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
                DbService.SaveUser(DbService.ToUser(userModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(DbService.GetUser(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DbService.GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                DbService.Update(userModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            DbService.DeleteUser(id);
            return RedirectToAction("Index");
        }


    }
}