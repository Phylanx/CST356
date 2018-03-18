using Lab_9.Data;
using Lab_9.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab_9.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly AppDbContext _db;

        
        public UserController()
        {
            _db = new AppDbContext();
        }

        [Route("api/user")]
        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        [Route("api/user/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _db.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }



    }
}
