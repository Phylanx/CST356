using Lab5_v3.Data;
using Lab5_v3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v3.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) { _db = db; }
        public User GetUser(int id) { return _db.Users.Find(id); }
        public IEnumerable<User> GetAllUsers() { return _db.Users; }
        public void SaveUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void UpdateUser(User user) {
            _db.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _db.Users.Find(id);
            if(user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return;
        }
    }
}