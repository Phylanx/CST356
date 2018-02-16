using System.ComponentModel.DataAnnotations;

namespace Lab_4.Data.Entities
{
    public class PC
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GB_Memory { get; set; }
        public int GB_Storage { get; set; }
        public int MHZ_Processor { get; set; }
        public bool ReadyForUpgrade { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}