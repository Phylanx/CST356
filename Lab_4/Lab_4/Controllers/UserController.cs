using Lab_4.Data;
using Lab_4.Data.Entities;
using Lab_4.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(GetAllUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userModel)
        {
            if(ModelState.IsValid)
            {
                SaveUser(ToUser(userModel));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(GetUser(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                Update(userModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);
            return RedirectToAction("Index");
        }
        
        private IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModel = new List<UserViewModel>();
            var db = new AppDbContext();
            foreach (var user in db.Users)
            {
                userViewModel.Add(ToModel(user));
            }
            return userViewModel;
        }

        public UserViewModel GetUser(int id)
        {
            var user = new AppDbContext().Users.Find(id);
            return ToModel(user);
        }

        private UserViewModel ToModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DOB,
                Fingers = user.Fingers
            };
        }

        private User ToUser(UserViewModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                MiddleName = userModel.MiddleName,
                LastName = userModel.LastName,
                EmailAddress = userModel.EmailAddress,
                DOB = userModel.DOB,
                Fingers = userModel.Fingers
            };
        }

        private void SaveUser(User user)
        {
            var db = new AppDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        private void Update(UserViewModel userModel)
        {
            var db = new AppDbContext();
            var user = db.Users.Find(userModel.Id);
            ModifyUser(user, userModel);
            db.SaveChanges();
        }

        private void ModifyUser(User user, UserViewModel userModel)
        {
            user.FirstName = userModel.FirstName;
            user.MiddleName = userModel.MiddleName;
            user.LastName = userModel.LastName;
            user.EmailAddress = userModel.EmailAddress;
            user.DOB = userModel.DOB;
            user.Fingers = userModel.Fingers;
        }

        private void DeleteUser(int id)
        {
            var db = new AppDbContext();
            foreach(PC pc in db.PCs)
            {
                if (pc.UserId == id) db.PCs.Remove(pc);
            }

            db.Users.Remove( db.Users.Find(id) );
            db.SaveChanges();
        }

        
    }
}