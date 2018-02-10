using Lab_4.Data;
using Lab_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class ProjectController : Controller
    {


        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            return View(GetProjects(id));
        }

        [HttpGet]
        public ActionResult Create(int userId = 0)
        {
            var project = new ProjectModel();
            project.UserId = userId;
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                SaveProject(project);

                return RedirectToAction("Details", "User", project.UserId);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var project = new WebAppDBContext().Projects.Find(id);
            return View(project);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new WebAppDBContext().Projects.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                SaveProject(project);

                return RedirectToAction("Details", "User", project.UserId);
            }
            else
            {
                return View();
            }
        }

        private IEnumerable<ProjectModel> GetProjects()
        {
            var projects = new List<ProjectModel>();
            var dbContext = new WebAppDBContext();
            foreach (var project in dbContext.Projects)
            {
                projects.Add(new ProjectModel(project));
            }
            return projects;
        }

        private IEnumerable<ProjectModel> GetProjects(int userId)
        {
            var projects = new List<ProjectModel>();
            var dbContext = new WebAppDBContext();
            foreach (var project in dbContext.Projects)
            {
                if(project.UserId == userId)
                {
                    projects.Add(new ProjectModel(project));
                }
            }
            return projects;
        }

        private void SaveProject(ProjectModel project)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
        }

        private void SaveEditProject(ProjectModel project)
        {
            var dbContext = new WebAppDBContext();
            var oldProjectData = dbContext.Projects.Find(project.Id);
            dbContext.Projects.Remove(oldProjectData);
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
        }

        private void Delete(int projectId)
        {
            var db = new WebAppDBContext();
            db.Projects.Remove(db.Projects.Find(projectId));
            db.SaveChanges();
        }

        public String GetUser(int userId)
        {
            var dbContext = new WebAppDBContext();
            var user = dbContext.Users.Find(userId);
            return user.FirstName + " " + user.LastName;
        }
    }
}