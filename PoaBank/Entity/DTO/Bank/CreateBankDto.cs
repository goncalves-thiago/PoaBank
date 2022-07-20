using System.ComponentModel.DataAnnotations;

namespace PoaBank.Entity.DTO.Bank
{
    public class CreateBankDto
    {
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }
    }
}
