using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5_v2.Data;
using Lab5_v2.Data.Entities;
using Lab5_v2.Services;

namespace Lab5_v2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext context)
        {
            _db = context;
        }
        public void DeleteUser(int id)
        {
            _db.Users.Remove( _db.Users.Find(id) );
            _db.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public User GetUser(int id)
        {
            return _db.Users.Find(id);
        }

        public void SaveUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var oldUserRecord = _db.Users.Find(user.Id);
            oldUserRecord.fName = user.fName;
            oldUserRecord.mName = user.mName;
            oldUserRecord.lName = user.lName;
            oldUserRecord.age = user.age;
            _db.SaveChanges();
        }

        
    }
}

