using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_3.Data.Entities
{
    public class UserModel
    {
        public UserModel()
        { }
        public UserModel(UserModel user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            MiddleName = user.MiddleName;
            LastName = user.LastName;
            Email = user.Email;
            YearsInSchool = user.YearsInSchool;
            CarName = user.CarName;
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int YearsInSchool { get; set; }
        [Required]
        public string CarName { get; set; }
    }
}