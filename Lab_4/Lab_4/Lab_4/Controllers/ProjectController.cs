using Lab_4.Data;
using Lab_4.Data.Entities;
using Lab_4.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class ProjectController : Controller
    {


        [HttpGet]
        public ActionResult Index(int id)
        {
            var user = new WebAppDBContext().Users.Find(id);
            string name = user.FirstName + " " + user.LastName;
            ViewBag.UserName = name;
            return View(GetProjectsList(id));
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var project = new ProjectModel();
            project.UserId = id;
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                SaveProject(ExtractProject(project));

                return RedirectToAction("Index", project.UserId);
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
                SaveEditProject(ExtractProject(project));

                return RedirectToAction("Index", project.UserId);
            }
            else
            {
                return View();
            }
        }

        private ProjectListModel GetProjectsList(int id)
        {
            var projects = new List<ProjectModel>();
            var dbContext = new WebAppDBContext();
            foreach (var project in dbContext.Projects)
            {
                if(project.UserId == id)
                {
                    projects.Add(ExtractModel(project));
                }
            }
            return new ProjectListModel
            {
                UserId = id,
                ProjectName = "",
                StartDate = System.DateTime.Now,
                IsCompleted = false,
                ProjectsList = projects
            };
        }

        private Project ExtractProject(ProjectModel project)
        {
            return new Project
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                IsCompleted = project.IsCompleted,
                UserId = project.UserId,
                User = new WebAppDBContext().Users.Find(project.UserId)
            };
        }

        public ProjectModel ExtractModel(Project project)
        {
            return new ProjectModel
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                IsCompleted = project.IsCompleted,
                UserId = project.UserId
            };
        }

        private void SaveProject(Project project)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
        }

        private void SaveEditProject(Project project)
        {
            var dbContext = new WebAppDBContext();
            var oldProjectData = dbContext.Projects.Find(project.Id);
            dbContext.Projects.Remove(oldProjectData);
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
        }

        private void Delete(int id)
        {
            var dbContext = new WebAppDBContext();
            dbContext.Projects.Remove(dbContext.Projects.Find(id));
            dbContext.SaveChanges();
        }
    }
}