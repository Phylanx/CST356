using Lab5_v2.Data;
using Lab5_v2.Data.Entities;
using Lab5_v2.Models;
using Lab5_v2.Repositories;
using Lab5_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5_v2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }
        public ActionResult Index()
        {
            ViewBag.AverageAge = new BusinessLogicService(_userService).GetAverageAge();
            return View(  GetAllUserModels() );
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                SaveUser( user );
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(  GetUserModel(id)  );
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View( GetUserModel(id) );
        }
        
        private IEnumerable<UserViewModel> GetAllUserModels()
        {
            return _userService.GetAllUserModels();
        }

        private UserViewModel GetUserModel(int id)
        {
            return _userService.GetUserModel(id);
        }

        private void SaveUser(UserViewModel user)
        {
            _userService.SaveUser(user);
        }

        private void UpdateUser(UserViewModel user)
        {
            _userService.UpdateUser(user);
        }

        private void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
        
        ///
    }
}