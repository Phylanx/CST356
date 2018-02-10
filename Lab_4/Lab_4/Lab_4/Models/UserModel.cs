using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(UserModel other)
        {
            Id = other.Id;
            FirstName = other.FirstName;
            MiddleName = other.MiddleName;
            LastName = other.LastName;
            Email = other.Email;
            DateOfBirth = other.DateOfBirth;
            TypingStyle = other.TypingStyle;
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Typing style")]
        public string TypingStyle { get; set; }
    }
}