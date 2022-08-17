using BankServices.Domain.DTOS;
using BankServices.Domain.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Repo.Interfaces
{
    public interface IBankOpt
    {
        Task<ResponseModel> TranferBankToBank(BankTransferDTO bankTransferDTO);
        Task<ResponseModel> GetTransactionStatus(string transactionReference);
    }
}
