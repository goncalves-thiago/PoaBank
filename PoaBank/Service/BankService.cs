using PoaBank.Context;
using PoaBank.Entity;
using System.Linq;

namespace PoaBank.Service
{
    public class BankService
    {
        private BankContext _context;
        public BankService(BankContext bankContext)
        {
            _context = bankContext;
        }

        public void Save(Bank bank)
        {
            _context.bank.Add(bank);
            _context.SaveChanges();
        }

        public Bank GetById(int id)
        {
            return _context.bank.FirstOrDefault(b => b.Id == id);
        }
    }
}
