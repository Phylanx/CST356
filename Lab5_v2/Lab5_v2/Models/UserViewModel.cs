using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5_v2.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public String fName { get; set; }
        [Display(Name = "Middle Name")]
        public String mName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String lName { get; set; }
        [Display(Name = "Age (before beauty)")]
        public int age { get; set; }
    }
}