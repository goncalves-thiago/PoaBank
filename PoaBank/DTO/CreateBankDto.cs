using System.ComponentModel.DataAnnotations;

namespace PoaBank.Dto
{
    public class CreateBankDto
    {
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }
    }
}
