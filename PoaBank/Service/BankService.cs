using AutoMapper;
using FluentResults;
using PoaBank.Context;
using PoaBank.Dto;
using PoaBank.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PoaBank.Service
{
    public class BankService
    {
        private BankContext _context;
        private IMapper _mapper;
        public BankService(BankContext bankContext, IMapper mapper)
        {
            _context = bankContext;
            _mapper = mapper;
        }

        public Bank Add(CreateBankDto _bankDto)
        {
            Bank _bank = _mapper.Map<Bank>(_bankDto);
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
            return _context.bank.ToList();
        }

        public Result Update(int _id, CreateBankDto _bankDto)
        {
            var _bank = _context.bank.FirstOrDefault(b => b.Id == _id);
            if (_bank is null) return Result.Fail("Bank not found.");
            _mapper.Map(_bankDto, _bank);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int _id)
        {
            var _bank = _context.bank.FirstOrDefault(b => b.Id == _id);
            if (_bank is null) return Result.Fail("Bank not found");
            _context.Remove(_bank);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
