using Lab5_v2.Models;
using Lab5_v2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5_v2.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IShoesService _shoesService;
        public ShoesController(IShoesService service)
        {
            _shoesService = service;
        }
        // GET: Shoes

        public ActionResult Index(int userId)
        {
            ViewBag.UserId = userId;
            return View( _shoesService.GetAllUserShoes(userId) );
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ShoesViewModel shoes)
        {
            ViewBag.UserId = shoes.OwnerId;
            if(ModelState.IsValid)
            {
                _shoesService.SaveShoes( shoes );
                return RedirectToAction("Index", new { UserId = shoes.OwnerId });
            }
            return View();
        }
    }
}