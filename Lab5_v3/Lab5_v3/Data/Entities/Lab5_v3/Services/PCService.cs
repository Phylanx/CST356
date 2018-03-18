using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using Lab5_v3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Services
{
    public class PCService : IPCService
    {
        private readonly IPCRepository _rep;

        public PCService(IPCRepository rep) { _rep = rep; }
        public PCViewModel GetPC(int id) { return ToModel(_rep.GetPC(id)); }
        public IEnumerable<PCViewModel> GetAllUserPCs(int userId)
        {
            var pcs = new List<PCViewModel>();
            foreach(var pc in _rep.GetAllUserPCs(userId))
            {
                pcs.Add(ToModel(pc));
            }
            return pcs;
        }
        public void SavePC(PCViewModel pc) { _rep.SavePC(ToPc(pc)); }
        public void UpdatePC(PCViewModel pc)
        {
            var oldRecord = _rep.GetPC(pc.Id);
            oldRecord.Name = pc.Name;
            oldRecord.GB_Memory = pc.GB_Memory;
            oldRecord.GB_Storage = pc.GB_Storage;
            oldRecord.MHZ_Processor = pc.MHZ_Processor;
            oldRecord.ReadyForUpgrade = pc.ReadyForUpgrade;
            oldRecord.UserId = pc.UserId;
        }
        public void DeletePC(int id) { _rep.DeletePC(id); }
        public int GetTotalStorage(int userId)
        {
            var count = 0;
            foreach(var item in _rep.GetAllUserPCs(userId))
            {
                count += item.GB_Storage;
            }
            return count;
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
        private PC ToPc(PCViewModel pc)
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
    }
}