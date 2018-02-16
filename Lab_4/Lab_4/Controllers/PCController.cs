using Lab_4.Data;
using Lab_4.Data.Entities;
using Lab_4.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class PCController : Controller
    {
        
        public ActionResult Index( int userId )
        {
            ViewBag.UserId = userId;
            return View( GetUserPCs(userId) );
        }

        [HttpGet]
        public ActionResult Create( int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create( PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if( ModelState.IsValid)
            {
                save(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pcModel = GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

        [HttpPost]
        public ActionResult Edit(PCViewModel pc)
        {
            ViewBag.UserId = pc.UserId;
            if(ModelState.IsValid)
            {
                Update(pc);
                return RedirectToAction("Index", new { UserId = pc.UserId });
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var userId = GetPC(id).UserId;
            remove(id);
            return RedirectToAction("Index", new { UserId = userId });
        }

        public ActionResult Details(int id)
        {
            var pcModel = GetPC(id);
            ViewBag.UserId = pcModel.UserId;
            return View(pcModel);
        }

        private ICollection<PCViewModel> GetUserPCs(int userId)
        {
            var userPCModels = new List<PCViewModel>();
            var db = new AppDbContext();
            foreach (var pc in db.PCs)
            {
                if (pc.UserId == userId)
                {
                    userPCModels.Add(ToModel(pc));
                }
            }
            return userPCModels;
        }

        private PCViewModel GetPC(int id)
        {
            var db = new AppDbContext();
            var pc = db.PCs.Find(id);
            return ToModel(pc);
        }

        private PCViewModel ToModel(PC pc)
        {
            return new PCViewModel
            {
                Id = pc.Id,
                Name = pc.Name,
                GB_Memory = pc.GB_Memory,
                GB_Storage = pc.GB_Storage,
                MHZ_Processor = pc.MHZ_Processor,
                ReadyForUpgrade = pc.ReadyForUpgrade,
                UserId = pc.UserId
            };
        }

        private PC ToPC(PCViewModel pc)
        {
            return new PC
            {
                Id = pc.Id,
                Name = pc.Name,
                GB_Memory = pc.GB_Memory,
                GB_Storage = pc.GB_Storage,
                MHZ_Processor = pc.MHZ_Processor,
                ReadyForUpgrade = pc.ReadyForUpgrade,
                UserId = pc.UserId
            };
        }

        private void save(PCViewModel pc)
        {
            var db = new AppDbContext();
            db.PCs.Add(ToPC(pc));
            db.SaveChanges();
        }

        private void Update(PCViewModel pc)
        {
            var db = new AppDbContext();

            var pcToUpdate = db.PCs.Find(pc.Id);
            
            pcToUpdate.Name = pc.Name;
            pcToUpdate.GB_Memory = pc.GB_Memory;
            pcToUpdate.GB_Storage = pc.GB_Storage;
            pcToUpdate.MHZ_Processor = pc.MHZ_Processor;
            pcToUpdate.ReadyForUpgrade = pc.ReadyForUpgrade;
            pcToUpdate.UserId = pc.UserId;

            db.SaveChanges();
        }

        private void remove(int id)
        {
            var db = new AppDbContext();
            var pc = db.PCs.Find(id);

            if(pc != null)
            {
                db.PCs.Remove(pc);
                db.SaveChanges();
            }
        }


        
    }
}