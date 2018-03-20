using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.UserEntities
{
    public class Car
    {
        [Key]
        [MinLength(10)]
        public String Id { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public String Color { get; set; }
        public String OwnerId { get; set; }
    }
}
