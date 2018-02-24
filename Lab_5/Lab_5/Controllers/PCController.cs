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
    public class PCController : Controller
    {
        private IDataService Service {get; set;}

        public PCController(IDataService service)
        {
            Service = service;
        }

        public ActionResult Index(int userId)
        {
            ViewBag.UserId = userId;
            return View(Service.GetUserPCs(userId));
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
                Service.savePc(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pcModel = Service.GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

        [HttpPost]
        public ActionResult Edit(PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if (ModelState.IsValid)
            {
                Service.UpdatePc(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var userId = Service.GetPC(id).UserId;
            Service.removePc(id);
            return RedirectToAction("Index", new { UserId = userId });
        }

        public ActionResult Details(int id)
        {
            var pcModel = Service.GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

    }
}