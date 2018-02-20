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
    public class PCController : Controller
    {
        private Repository DbService {get; set;}
        
        public PCController()
        {
            DbService = new Repository(new AppDbContext());
        }

        public PCController(Repository repository)
        {
            DbService = repository;
        }

        public ActionResult Index(int userId)
        {
            ViewBag.UserId = userId;
            return View(DbService.GetUserPCs(userId));
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if (ModelState.IsValid)
            {
                DbService.savePc(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pcModel = DbService.GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

        [HttpPost]
        public ActionResult Edit(PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if (ModelState.IsValid)
            {
                DbService.UpdatePc(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var userId = DbService.GetPC(id).UserId;
            DbService.removePc(id);
            return RedirectToAction("Index", new { UserId = userId });
        }

        public ActionResult Details(int id)
        {
            var pcModel = DbService.GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

    }
}