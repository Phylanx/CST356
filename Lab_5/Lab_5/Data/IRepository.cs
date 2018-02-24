using Lab_5.Data.Entities;
using Lab_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_5.Data
{
    public interface IRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        ////
        ICollection<PC> GetUserPCs(int userId);
        PC GetPC(int id);
        void SavePc(PC pc);
        void UpdatePc(PC pc);
        void DeletePc(int id);


    }
}