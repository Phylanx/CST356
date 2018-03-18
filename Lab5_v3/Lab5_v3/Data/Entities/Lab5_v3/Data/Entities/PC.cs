using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5_v3.Data.Entities
{
    public class PC
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GB_Memory { get; set; }
        public int GB_Storage { get; set; }
        public int MHZ_Processor { get; set; }
        public bool ReadyForUpgrade { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}