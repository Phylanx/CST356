﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Completion Status")]
        public bool IsCompleted { get; set; } = false;

        [Required]
        public int UserId { get; set; }
    }
}