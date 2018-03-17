using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_8.Models
{
    public class JobModel
    {
        [Key]
        public int JobId { get; set; }
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public String Title { get; set; }
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Display(Name = "Salary")]
        public int Salary { get; set; }
        [Display(Name = "Hourly or Yearly")]
        public bool SalaryIsYearly { get; set; }
    }
}