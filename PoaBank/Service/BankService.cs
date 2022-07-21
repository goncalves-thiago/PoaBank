using FluentResults;
using PoaBank.Context;
using PoaBank.Entity;
using PoaBank.Entity.DTO;
using System.Collections.Generic;
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

        public Bank Add(CreateBankDto _bankDto)
        {
            Bank _bank = new Bank();
            _bank.Code = _bankDto.Code;
            _bank.Name = _bankDto.Name;
            _context.bank.Add(_bank);
            _context.SaveChanges();
            return _bank;
        }

        public Bank GetById(int _id)
        {
            return _context.bank.FirstOrDefault(b => b.Id == _id);
        }

        public IEnumerable<Bank> Get()
        {
            List<Bank> _bank;
            _bank = _context.bank.ToList();
            return _bank;
        }

        public void Update(int _id, string _code, string _name)
        {
            var _bank = _context.bank.FirstOrDefault(b => b.Id == _id);
            _bank.Name = _name;
            _bank.Code = _code;
            _context.SaveChanges();
}

        public Result Delete(int _id)
        {
            Bank _bank = GetById(_id);

            if(_bank is null)
            {
                return Result.Fail("Erro ao deletar!");
            }

            _context.Remove(_bank);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
