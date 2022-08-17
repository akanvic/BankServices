using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Domain.DTOS
{
    public class BankTransferDTO
    {
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public decimal Amount { get; set; }
        public string RecieverAcctNumber { get; set; }
        public string CustomerBank { get; set; }
    }
}
