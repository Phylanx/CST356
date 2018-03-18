using Lab5_v3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}