using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAccountNumber { get; set; }
        public decimal CustomerAccountBalanace { get; set; }
        public string CustomerBank { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
