using Lab_5.Data;
using Lab_5.Data.Entities;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Services
{
    public class DataService : IDataService
    {
        private IRepository Data { get; set; }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = Data.GetAllUsers();
            var userModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userModels.Add( ToModel(user) );
            }
            return userModels;
        }

        public UserViewModel GetUser(int id)
        {
            return ToModel(Data.GetUser(id));
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
            Data.SaveUser(user);
        }

        public void Update(UserViewModel userModel)
        {
            Data.UpdateUser(ToUser(userModel));
        }

        public void DeleteUser(int id)
        {
            Data.DeleteUser(id);
        }

        ///////


        public ICollection<PCViewModel> GetUserPCs(int userId)
        {
            var pcs = Data.GetUserPCs(userId);
            var pcModels = new List<PCViewModel>();
            foreach(PC pc in pcs)
            {
                pcModels.Add(ToPcModel(pc));
            }
            return pcModels;
        }

        public PCViewModel GetPC(int id)
        {
            return ToPcModel(Data.GetPC(id));
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
            Data.SavePc(ToPC(pc));
        }

        public void UpdatePc(PCViewModel pc)
        {
            Data.UpdatePc(ToPC(pc));
        }

        public void removePc(int id)
        {
            Data.DeletePc(id);
        }


        ////
    }
}