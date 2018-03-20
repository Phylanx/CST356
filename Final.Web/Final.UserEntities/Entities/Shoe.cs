using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.UserEntities
{
    public class Shoe
    {
        [Key]
        public int Id { get; set; }
        public String Color { get; set; }
        public String Brand { get; set; }
        public String Style { get; set; }
        public bool IsPair { get; set; }
        public String OwnerId { get; set; }
    }
}
