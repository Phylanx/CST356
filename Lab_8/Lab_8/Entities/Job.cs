using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_8.Entities
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public int UserId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Salary { get; set; }
        public bool SalaryIsYearly { get; set; }

    }
}