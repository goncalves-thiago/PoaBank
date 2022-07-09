using Microsoft.EntityFrameworkCore;
using PoaBank.Entity;

namespace PoaBank.Context
{
    public class BankContext : DbContext
    {
        public DbSet<Bank> banks { get; set; }

        public BankContext(DbContextOptions<BankContext> opt) : base(opt)
        {

        }
    }
}
