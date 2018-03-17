using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public String FName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public String MName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String LName { get; set; }
        [Display(Name = "Birthday")]
        public DateTime BDay { get; set; }
    }
}