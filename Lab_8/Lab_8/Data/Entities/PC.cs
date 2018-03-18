using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab_8.Data.Entities
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
        [ForeignKey("User")]
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}