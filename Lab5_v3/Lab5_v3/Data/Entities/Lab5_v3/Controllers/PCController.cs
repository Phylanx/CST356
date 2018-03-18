using Lab5_v3.Data;
using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using Lab5_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5_v3.Controllers
{
    public class PCController : Controller
    {
        private readonly IPCService _serv;

        public PCController(IPCService service) { _serv = service; }
        public ActionResult Index(int userId)
        {
            ViewBag.TotalStorage = _serv.GetTotalStorage(userId);
            ViewBag.UserId = userId;
            return View(_serv.GetAllUserPCs(userId));
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
                _serv.SavePC(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.UserId = id;
            return View(_serv.GetPC(id));
        }

        [HttpPost]
        public ActionResult Edit(PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if (ModelState.IsValid)
            {
                _serv.UpdatePC(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _serv.DeletePC(id);
            return RedirectToAction("Index", new { UserId = id });
        }

        public ActionResult Details(int id)
        {
            ViewBag.UserId = id;
            return View(_serv.GetPC(id));
        }

       
    }
}