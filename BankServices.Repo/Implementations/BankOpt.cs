using BankServices.Domain.DTOS;
using BankServices.Domain.Models;
using BankServices.Domain.Reponses;
using BankServices.Repo.Data;
using BankServices.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.Repo.Implementations
{
    public class BankOpt : IBankOpt
    {
        private PaymentContext _paymentContext;
        public BankOpt(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }

        public async Task<ResponseModel> TranferBankToBank(BankTransferDTO bankTransferDTO)
        {
            var recieverAccountNumber = await _paymentContext.Customers
                               .FirstOrDefaultAsync(c => c.CustomerAccountNumber == bankTransferDTO.RecieverAcctNumber)!;
            if (recieverAccountNumber == null)
                return new ResponseModel { State = 0, Msg = "Reciever Account number does not exist", Data = bankTransferDTO.RecieverAcctNumber };

            var senderAccount = await _paymentContext.Customers
                   .FirstOrDefaultAsync(c => c.EmailAddress == bankTransferDTO.SenderEmail &&
                   c.Password == bankTransferDTO.SenderPassword)!;
        

            if (senderAccount == null)
                return new ResponseModel 
                { 
                  State = 0, 
                  Msg = "Senders Account Email or Password is Incorrect or Does not exist"
                };

            if(senderAccount.CustomerAccountBalanace < bankTransferDTO.Amount)
                return new ResponseModel { State = 0, 
                                           Msg = "Insufficient Account Balance", 
                                           Data = senderAccount.CustomerAccountBalanace! };

            senderAccount.CustomerAccountBalanace -= bankTransferDTO.Amount;
            recieverAccountNumber.CustomerAccountBalanace += bankTransferDTO.Amount;

            TransactionHistory transaction = new TransactionHistory()
            {
                SenderAccountName = senderAccount.CustomerName,
                AmountTransferred = bankTransferDTO.Amount,
                TrxRef = "TR" + GenerateTransactionReference().ToString(),
                SenderAccountEmail = senderAccount.EmailAddress,
                RecieverAccountName = recieverAccountNumber.CustomerName,
                RecieverAccountEmail = recieverAccountNumber.EmailAddress,
                TransactionStatus = true
            };

            await _paymentContext.TransactionHistories.AddAsync(transaction);

            int ret = await _paymentContext.SaveChangesAsync();

            if(ret <= 0)
                return new ResponseModel { State = 0, Msg = "Transaction update was not successfully saved to the database", Data = ret! };

            return new ResponseModel { State = 1, 
                                       Msg = $"Transfer Successful, {bankTransferDTO.Amount} has been transferred to {recieverAccountNumber.CustomerName}", 
                                       Data = senderAccount.CustomerName! };

        }

        public static int GenerateTransactionReference()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }

        public async Task<ResponseModel> GetTransactionStatus(string transactionReference)
        {
            var ret = await _paymentContext.TransactionHistories.
                                        FirstOrDefaultAsync(c => c.TrxRef.Equals(transactionReference));
            if (ret == null)
                return new ResponseModel { State = 0, Msg = "Transaction reference does not exists in the database", Data = ret! };

            if (ret.TransactionStatus == true) 
            {
                return new ResponseModel
                {
                    State = 1,
                    Msg = $"Transfer made by {ret.SenderAccountName} on {ret.TransactionDate} to {ret.RecieverAccountName} was successful",
                    Data = ret
                };
            }
            return new ResponseModel
            {
                State = 0,
                Msg = $"Transfer made by {ret.SenderAccountName} on {ret.TransactionDate} to {ret.RecieverAccountName} was not successful",
                Data = ret
            };
        }
    }
}
