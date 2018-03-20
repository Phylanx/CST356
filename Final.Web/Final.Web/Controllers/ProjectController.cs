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
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService serv)
        {
            _service = serv;
        }



        public ActionResult ProjectIndex()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View(_service.GetUserProjects(ViewBag.UserId));
        }



        [HttpGet]
        public ActionResult ProjectCreate()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }
        [HttpPost]
        public ActionResult ProjectCreate(ProjectModel project)
        {
            ViewBag.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _service.CreateProject(project);
                return RedirectToAction("ProjectIndex");
            }
            return View();
        }



        [HttpGet]
        public ActionResult ProjectUpdate(int id)
        {
            return View(_service.GetProject(id));
        }
        [HttpPost]
        public ActionResult ProjectUpdate(ProjectModel project)
        {
            if(ModelState.IsValid)
            {
                _service.UpdateProject(project);
                return RedirectToAction("ProjectIndex");
            }
            return View();
        }



        public ActionResult ProjectDelete(int id)
        {
            _service.DeleteProject(id);
            return RedirectToAction("ProjectIndex");
        }



        [HttpGet]
        public ActionResult ProjectInfo(int id)
        {
            return View(_service.GetProject(id));
        }


        //end controller
    }
}