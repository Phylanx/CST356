using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class ProjectModel
    {
        public ProjectModel() { }
        public ProjectModel(ProjectModel project)
        {
            Id = project.Id;
            ProjectName = project.ProjectName;
            StartDate = project.StartDate;
            EndDate = project.EndDate;
            UserId = project.UserId;
        }
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}