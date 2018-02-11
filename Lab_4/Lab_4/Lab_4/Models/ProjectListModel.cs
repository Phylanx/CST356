using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class ProjectListModel
    {
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Completion Status")]
        public bool IsCompleted { get; set; } = false;

        [Required]
        public ICollection<ProjectModel> ProjectsList { get; set; }
    }
}