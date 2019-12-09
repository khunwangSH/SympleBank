using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Services
{
    public interface IIBANService
    {
        bool Validate(string IBAN);
    }
}
