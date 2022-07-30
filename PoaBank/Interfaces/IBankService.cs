using FluentResults;
using PoaBank.Dto;
using PoaBank.Entity;
using System.Collections.Generic;

namespace PoaBank.Interfaces
{
    public interface IBankService
    {
        public Bank Add(CreateBankDto _bankDto);

        public Bank Get(int _id);

        public IEnumerable<Bank> Get();

        public Result Update(int _id, CreateBankDto _bankDto);

        public Result Delete(int _id);
    }
}
