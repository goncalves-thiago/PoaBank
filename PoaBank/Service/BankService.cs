using AutoMapper;
using FluentResults;
using PoaBank.Dto;
using PoaBank.Entity;
using PoaBank.Interfaces;
using System.Collections.Generic;

namespace PoaBank.Service
{
    public class BankService : IBankService
    {
        private IRepository<Bank> _repository;
        private IMapper _mapper;
        public BankService(IRepository<Bank> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Bank Add(CreateBankDto _bankDto)
        {
            Bank _bank = _mapper.Map<Bank>(_bankDto);
            _repository.Create(_bank);
            return _bank;
        }

        public Bank Get(int _id)
        {
            return _repository.Get(_id);
        }

        public IEnumerable<Bank> Get()
        {
            return _repository.Get();
        }

        public Result Update(int _id, CreateBankDto _bankDto)
        {
            var _bank = _repository.Get(_id);
            if (_bank is null) return Result.Fail("Bank not found.");
            _mapper.Map(_bankDto, _bank);
            _repository.Update(_bank);
            return Result.Ok();
        }

        public Result Delete(int _id)
        {
            var _bank = _repository.Get(_id);
            if (_bank is null) return Result.Fail("Bank not found");
            _repository.Delete(_bank);
            return Result.Ok();
        }
    }
}
