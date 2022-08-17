using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Domain.Models
{
    public class TransactionHistory
    {
        [Key]
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string SenderAccountName { get; set; }
        public decimal AmountTransferred { get; set; }
        public string TrxRef { get; set; }
        public string SenderAccountEmail { get; set; }
        public string RecieverAccountName { get; set; }
        public string RecieverAccountEmail { get; set; }
        public bool TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
