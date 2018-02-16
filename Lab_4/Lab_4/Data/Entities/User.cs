using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_4.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public int Fingers { get; set; }
        //public ICollection<PC> PC { get; set; }
    }
}