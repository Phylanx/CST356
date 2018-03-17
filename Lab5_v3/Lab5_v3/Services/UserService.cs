using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using Lab5_v3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _rep;

        public UserService(IUserRepository rep) { _rep = rep; }
        public UserViewModel GetUser(int id) { return ToModel(_rep.GetUser(id)); }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var allUsers = new List<UserViewModel>();
            foreach(var user in _rep.GetAllUsers())
            {
                allUsers.Add(ToModel(user));
            }
            return allUsers;
        }
        public void SaveUser(UserViewModel user) { _rep.SaveUser(ToUser(user)); }
        public void UpdateUser(UserViewModel user)
        {
            var oldRecord = _rep.GetUser(user.Id);
            oldRecord.FirstName = user.FirstName;
            oldRecord.MiddleName = user.MiddleName;
            oldRecord.LastName = user.LastName;
            oldRecord.EmailAddress = user.EmailAddress;
            oldRecord.DOB = user.DOB;
            oldRecord.Fingers = user.Fingers;
        }
        public void DeleteUser(int id) { _rep.DeleteUser(id); }
        public double GetAverageFingers()
        {
            var fingers = 0.0;
            var count = 0;
            foreach(var user in _rep.GetAllUsers())
            {
                count++;
                fingers += user.Fingers;
            }
            return (count > 0) ? (fingers / count) : 0;
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
        private User ToUser(UserViewModel user)
        {
            return new User
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

    }
}