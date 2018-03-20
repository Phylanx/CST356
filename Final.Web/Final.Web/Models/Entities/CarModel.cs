using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Web.Models.Entities
{
    public class CarModel
    {
        [Key]
        [MinLength(10)]
        [Display(Name = "VIN")]
        public String Id { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Color { get; set; }
        public String OwnerId { get; set; }
    }
}