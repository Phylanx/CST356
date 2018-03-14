using Lab5_v2.Data.Entities;
using Lab5_v2.Models;
using Lab5_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Services
{
    /**
     * takes repository entity, returns entity model
     * **/
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserViewModel> GetAllUserModels()
        {
            var users = new List<UserViewModel>();
            foreach(User user in _repository.GetAllUsers())
            {
                users.Add(ToUserModel(user));
            }
            return users;
        }
        public UserViewModel GetUserModel(int id)
        {
            return ToUserModel(  _repository.GetUser(id)  );
        }
        public void SaveUser(UserViewModel user)
        {
            _repository.SaveUser( ToUser(user) );
        }
        public void UpdateUser(UserViewModel user)
        {
            _repository.UpdateUser( ToUser(user) );
        }
        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }
        private UserViewModel ToUserModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                fName = user.fName,
                mName = user.mName,
                lName = user.lName,
                age = user.age
            };
        }
        private User ToUser(UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                fName = user.fName,
                mName = user.mName,
                lName = user.lName,
                age = user.age
            };
        }
        
    }
}