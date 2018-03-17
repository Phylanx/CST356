using Lab_8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_8.Controllers
{
    public class UserController : Controller
    {
        private readonly IService _service;
        public UserController(IService service)
        {
            _service = service;
        }
        public ActionResult UserList()
        {
            return View();
        }
    }
}