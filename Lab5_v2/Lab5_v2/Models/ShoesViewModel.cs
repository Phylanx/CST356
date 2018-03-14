using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5_v2.Models
{
    public class ShoesViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type")]
        public String Type { get; set; }
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Size")]
        public double Size { get; set; }
        [Display(Name = "Re-Sell Value")]
        public double Value { get; set; }
        public int OwnerId { get; set; }
    }
}