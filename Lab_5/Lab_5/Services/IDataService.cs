using Lab_5.Data;
using Lab_5.Data.Entities;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Services
{
    public interface IDataService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUser(int id);
        User ToUser(UserViewModel userModel);
        void SaveUser(User user);
        void Update(UserViewModel userModel);
        void DeleteUser(int id);
        ////
        ICollection<PCViewModel> GetUserPCs(int userId);
        PCViewModel GetPC(int id);
        PC ToPC(PCViewModel pc);
        void savePc(PCViewModel pc);
        void UpdatePc(PCViewModel pc);
        void removePc(int id);
    }
}