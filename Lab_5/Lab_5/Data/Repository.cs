using Lab_5.Data.Entities;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_5.Data
{
    public class Repository : IRepository
    {
        public Repository(AppDbContext context)
        {
            Data = context;
        }

        private AppDbContext Data { get; set; }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            
            foreach (var user in Data.Users)
            {
                users.Add(user);
            }
            return users;
        }

        public User GetUser(int id)
        {
            return Data.Users.Find(id);
        }
        
        public void SaveUser(User user)
        {
            Data.Users.Add(user);
            Data.SaveContextChanges();
        }

        public void UpdateUser(User user)
        {
            var oldUser = Data.Users.Find(user.Id);

            oldUser.FirstName = user.FirstName;
            oldUser.MiddleName = user.MiddleName;
            oldUser.LastName = user.LastName;
            oldUser.EmailAddress = user.EmailAddress;
            oldUser.DOB = user.DOB;
            oldUser.Fingers = user.Fingers;
            
            Data.SaveContextChanges();
        }

        public void DeleteUser(int id)
        {
            foreach (PC pc in Data.PCs)
            {
                if (pc.UserId == id) Data.PCs.Remove(pc);
            }

            Data.Users.Remove(Data.Users.Find(id));
            Data.SaveContextChanges();
        }

        ///////


        public ICollection<PC> GetUserPCs(int userId)
        {
            var PCs = new List<PC>();
            foreach (var pc in Data.PCs)
            {
                if (pc.UserId == userId)
                {
                    PCs.Add(pc);
                }
            }
            return PCs;
        }

        public PC GetPC(int id)
        {
            return Data.PCs.Find(id);
        }
       
        public void SavePc(PC pc)
        {
            Data.PCs.Add(pc);
            Data.SaveContextChanges();
        }

        public void UpdatePc(PC pc)
        {
            var oldPc = Data.PCs.Find(pc.Id);

            oldPc.Name = pc.Name;
            oldPc.GB_Memory = pc.GB_Memory;
            oldPc.GB_Storage = pc.GB_Storage;
            oldPc.MHZ_Processor = pc.MHZ_Processor;
            oldPc.ReadyForUpgrade = pc.ReadyForUpgrade;
            oldPc.UserId = pc.UserId;

            Data.SaveContextChanges();
        }

        public void DeletePc(int id)
        {
            var pc = Data.PCs.Find(id);

            if (pc != null)
            {
                Data.PCs.Remove(pc);
                Data.SaveContextChanges();
            }
        }
    }
}