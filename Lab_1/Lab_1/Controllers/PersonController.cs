using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            ViewBag.Name = "Garry";
            ViewBag.Age = 57;
            ViewBag.Shoes = "Slippers";
            return View();
        }
    }
}