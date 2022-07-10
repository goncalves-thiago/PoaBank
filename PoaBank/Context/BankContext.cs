using Microsoft.EntityFrameworkCore;
using PoaBank.Entity;

namespace PoaBank.Context
{
    public class BankContext : DbContext
    {
        public DbSet<Bank> bank { get; set; }

        public BankContext(DbContextOptions<BankContext> opt) : base(opt)
        {

        }
    }
}
