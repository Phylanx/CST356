using Final.Web.Models.Entities;
using Final.Web.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Final.Web.Controllers
{
    public class ShoeController : Controller
    {
        private IShoeService _service;
        public ShoeController(IShoeService serv)
        {
            _service = serv;
        }



        public ActionResult ShoeIndex()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View(_service.GetUserShoes(ViewBag.UserId));
        }



        [HttpGet]
        public ActionResult ShoeCreate()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }
        [HttpPost]
        public ActionResult ShoeCreate(ShoeModel shoe)
        {
            ViewBag.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _service.CreateShoe(shoe);
                return RedirectToAction("ShoeIndex");
            }
            return View();
        }



        [HttpGet]
        public ActionResult ShoeUpdate(int id)
        {
            return View(_service.GetShoe(id));
        }
        [HttpPost]
        public ActionResult ShoeUpdate(ShoeModel shoe)
        {
            if(ModelState.IsValid)
            {
                _service.UpdateShoe(shoe);
                return RedirectToAction("ShoeIndex");
            }
            return View();
        }



        public ActionResult ShoeDelete(int id)
        {
            _service.DeleteShoe(id);
            return RedirectToAction("ShoeIndex");
        }



        [HttpGet]
        public ActionResult ShoeInfo(int id)
        {
            return View(_service.GetShoe(id));
        }

    }
}