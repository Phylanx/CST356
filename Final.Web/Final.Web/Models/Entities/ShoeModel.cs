using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Web.Models.Entities
{
    public class ShoeModel
    {
        [Key]
        public int Id { get; set; }
        public String Color { get; set; }
        public String Brand { get; set; }
        public String Style { get; set; }
        public String OwnerId { get; set; }
        public bool IsPair { get; set; }
    }
}