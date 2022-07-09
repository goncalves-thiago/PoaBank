using System.ComponentModel.DataAnnotations;

namespace PoaBank.Entity
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
