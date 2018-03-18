using Lab5_v3.Data;
using Lab5_v3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Repositories
{
    public class PCRepository : IPCRepository
    {
        private readonly AppDbContext _db;

        public PCRepository(AppDbContext db) { _db = db; }
        public PC GetPC(int id) { return _db.PCs.Find(id); }
        public IEnumerable<PC> GetAllUserPCs(int userId) { return _db.PCs.Where(pc => pc.UserId == userId).ToList(); }
        public void SavePC(PC pc)
        {
            _db.PCs.Add(pc);
            _db.SaveChanges();
        }
        public void UpdatePC(PC pc) { _db.SaveChanges(); }
        public void DeletePC(int id)
        {
            var pc = _db.PCs.Find(id);
            if(pc != null)
            {
                _db.PCs.Remove(pc);
                _db.SaveChanges();
            }
            return;
        }
    }
}