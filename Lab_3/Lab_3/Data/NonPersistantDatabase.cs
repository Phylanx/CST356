using Lab_3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_3.Data
{
    public class NonPersistantDatabase
    {
        public static List<UserModel> Users = new List<UserModel>();
        public static int NextId = 0;

        public static int getNextId()
        {
            return NextId++;
        }

        public static void RemoveUser(int id)
        {
            var userToRemove = Users.Find(u => u.Id == id);
            Users.Remove(userToRemove);
        }

        public static UserModel FindUser(int id)
        {
            return Users.Find(u => u.Id == id);
        }
    }
}