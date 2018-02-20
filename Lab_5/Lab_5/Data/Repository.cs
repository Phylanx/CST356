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

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();
            
            foreach (var user in Data.Users)
            {
                userViewModels.Add(ToModel(user));
            }
            return userViewModels;
        }

        public UserViewModel GetUser(int id)
        {
            var user = Data.Users.Find(id);
            return ToModel(user);
        }

        private UserViewModel ToModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DOB,
                Fingers = user.Fingers
            };
        }

        public User ToUser(UserViewModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                MiddleName = userModel.MiddleName,
                LastName = userModel.LastName,
                EmailAddress = userModel.EmailAddress,
                DOB = userModel.DOB,
                Fingers = userModel.Fingers
            };
        }

        public void SaveUser(User user)
        {
            Data.Users.Add(user);
            Data.SaveChanges();
        }

        public void Update(UserViewModel userModel)
        {
            var user = Data.Users.Find(userModel.Id);
            ModifyUser(user, userModel);
            Data.SaveChanges();
        }

        private void ModifyUser(User user, UserViewModel userModel)
        {
            user.FirstName = userModel.FirstName;
            user.MiddleName = userModel.MiddleName;
            user.LastName = userModel.LastName;
            user.EmailAddress = userModel.EmailAddress;
            user.DOB = userModel.DOB;
            user.Fingers = userModel.Fingers;
        }

        public void DeleteUser(int id)
        {
            foreach (PC pc in Data.PCs)
            {
                if (pc.UserId == id) Data.PCs.Remove(pc);
            }

            Data.Users.Remove(Data.Users.Find(id));
            Data.SaveChanges();
        }

        ///////


        public ICollection<PCViewModel> GetUserPCs(int userId)
        {
            var userPCModels = new List<PCViewModel>();
            foreach (var pc in Data.PCs)
            {
                if (pc.UserId == userId)
                {
                    userPCModels.Add(ToPcModel(pc));
                }
            }
            return userPCModels;
        }

        public PCViewModel GetPC(int id)
        {
            var db = new AppDbContext();
            var pc = db.PCs.Find(id);
            return ToPcModel(pc);
        }

        private PCViewModel ToPcModel(PC pc)
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

        public PC ToPC(PCViewModel pc)
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

        public void savePc(PCViewModel pc)
        {
            Data.PCs.Add(ToPC(pc));
            Data.SaveChanges();
        }

        public void UpdatePc(PCViewModel pc)
        {
            var pcToUpdate = Data.PCs.Find(pc.Id);

            pcToUpdate.Name = pc.Name;
            pcToUpdate.GB_Memory = pc.GB_Memory;
            pcToUpdate.GB_Storage = pc.GB_Storage;
            pcToUpdate.MHZ_Processor = pc.MHZ_Processor;
            pcToUpdate.ReadyForUpgrade = pc.ReadyForUpgrade;
            pcToUpdate.UserId = pc.UserId;

            Data.SaveChanges();
        }

        public void removePc(int id)
        {
            var pc = Data.PCs.Find(id);

            if (pc != null)
            {
                Data.PCs.Remove(pc);
                Data.SaveChanges();
            }
        }
    }
}