using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Models
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
