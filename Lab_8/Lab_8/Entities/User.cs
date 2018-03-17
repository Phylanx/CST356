using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_8.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String FName { get; set; }
        public String MName { get; set; }
        public String LName { get; set; }
        public DateTime BDay { get; set; }

    }
}