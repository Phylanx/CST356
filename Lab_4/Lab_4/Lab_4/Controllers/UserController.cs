using Lab_4.Data;
using Lab_4.Data.Entities;
using Lab_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(GetUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                SaveUser(userModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

       [HttpGet]
       public ActionResult Details(int id)
        {
            return View(GetUserModel(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(GetUserModel(id));
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                SaveEditUser(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Users.Remove(dbContext.Users.Find(id));
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        

        public UserModel GetUserModel(int id)
        {
            var user = new WebAppDBContext().Users.Find(id);
            return ExtractModel(user);
        }
        private IEnumerable<UserModel> GetUsers()
        {
            var users = new List<UserModel>();
            var dbContext = new WebAppDBContext();
            foreach (var user in dbContext.Users)
            {
                users.Add(ExtractModel(user));
            }
            return users;
        }

        private User ExtractUser(UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                MiddleName = userModel.MiddleName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                DateOfBirth = userModel.DateOfBirth,
                TypingStyle = userModel.TypingStyle
            };
        }

        private UserModel ExtractModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                TypingStyle = user.TypingStyle
            };
        }

        private void SaveUser(UserModel userModel)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Users.Add(ExtractUser(userModel));
            dbContext.SaveChanges();
        }

        private void SaveEditUser(UserModel userModel)
        {
            var dbContext = new WebAppDBContext();
            var oldUserData = dbContext.Users.Find(userModel.Id);
            dbContext.Users.Remove(oldUserData);
            dbContext.Users.Add(ExtractUser(userModel));
            dbContext.SaveChanges();
        }

        public void AddProject(Project project)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
        }
    }

}