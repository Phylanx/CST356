using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.UserEntities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public String Title { get; set; }
        [MaxLength(300)]
        public String Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public bool Completed { get; set; }
        public String OwnerId { get; set; }
    }
}
