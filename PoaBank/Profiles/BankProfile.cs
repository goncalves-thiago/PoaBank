using AutoMapper;
using PoaBank.Dto;
using PoaBank.Entity;

namespace PoaBank.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<CreateBankDto, Bank>();
        }
    }
}
