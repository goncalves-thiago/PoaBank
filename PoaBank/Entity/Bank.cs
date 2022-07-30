using Dapper.Contrib.Extensions;

namespace PoaBank.Entity
{
    [Table("[Bank]")]
    public class Bank
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}