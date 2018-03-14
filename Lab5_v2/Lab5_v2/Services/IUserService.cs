using Lab5_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Services
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUserModels();
        UserViewModel GetUserModel(int id);
        void SaveUser(UserViewModel user);
        void UpdateUser(UserViewModel user);
        void DeleteUser(int id);
    }
}