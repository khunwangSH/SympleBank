using AutoMapper;
using SimpleBank.Data.Entities;
using SimpleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<BankAccount, BankAccountViewModel>()
               .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id))
               .ReverseMap();

           
        }
    }
}
