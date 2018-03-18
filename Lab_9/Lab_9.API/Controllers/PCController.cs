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
    public class PCController : ApiController
    {
        private readonly AppDbContext _db;

        public PCController()
        {
            _db = new AppDbContext();
        }

        [Route("api/pc/all")]
        public IEnumerable<PC> GetAllPCs()
        {
            return _db.PCs.ToList();
        }

        [Route("api/user/pcs/{userId}")]
        public IEnumerable<PC> GetUserPCs(int userId)
        {
            var pcs = new List<PC>();
            foreach(var pc in _db.PCs)
            {
                if (pc.UserId == userId) pcs.Add(pc);
            }
            return pcs;
        }

        [Route("api/pc/{id}")]
        public IHttpActionResult GetPC(int id)
        {
            var pc = _db.PCs.Find(id);
            if(pc == null)
            {
                return NotFound();
            }
            return Ok(pc);
        }



        // end controller
    }
}
