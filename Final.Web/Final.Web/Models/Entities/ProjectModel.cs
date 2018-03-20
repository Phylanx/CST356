using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Web.Models.Entities
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        [MaxLength(50)]
        public String Title { get; set; }
        [Display(Name = "Description")]
        [MaxLength(300)]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }
        [Display(Name = "End Date")]
        public DateTime Finish { get; set; }
        [Required]
        [Display(Name = "Completed")]
        public bool Completed { get; set; }
        [Display(Name = "Participants")]
        public String OwnerId { get; set; }
    }
}