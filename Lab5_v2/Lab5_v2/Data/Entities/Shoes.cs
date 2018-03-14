using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5_v2.Data.Entities
{
    public class Shoes
    {
        [Key]
        public int Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public double Size { get; set; }
        public double Value { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}