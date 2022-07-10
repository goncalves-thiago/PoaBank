using System.ComponentModel.DataAnnotations;

namespace PoaBank.Entity
{   
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }
    }
}