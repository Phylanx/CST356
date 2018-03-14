using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5_v2.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String fName { get; set; }
        public String mName { get; set; }
        public String lName { get; set; }
        public int age { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
    }
}