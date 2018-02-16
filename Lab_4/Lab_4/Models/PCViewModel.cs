using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class PCViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "PC Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Memory Size (GB)")]
        public int GB_Memory { get; set; }
        [Required]
        [Display(Name = "Storage Size (GB)")]
        public int GB_Storage { get; set; }
        [Required]
        [Display(Name = "CPU speed (MHZ)")]
        public int MHZ_Processor { get; set; }
        [Required]
        [Display(Name = "Upgrade Needed")]
        public bool ReadyForUpgrade { get; set; }
        public int UserId { get; set; }
    }
}