using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_v3.Services
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        IEnumerable<UserViewModel> GetAllUsers();
        void SaveUser(UserViewModel user);
        void UpdateUser(UserViewModel user);
        void DeleteUser(int id);
        double GetAverageFingers();
    }
}
