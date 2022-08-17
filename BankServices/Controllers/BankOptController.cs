using BankServices.Domain.DTOS;
using BankServices.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankOptController : ControllerBase
    {
        private readonly IBankOpt _bankOpt;
        public BankOptController(IBankOpt bankOpt)
        {
            _bankOpt = bankOpt;
        }

        [HttpPost("TranferBankToBank")]
        public async Task<IActionResult> TranferBankToBank(BankTransferDTO bankTransferDTO)
        {
            try
            {
                var response = await _bankOpt.TranferBankToBank(bankTransferDTO);

                if (response.State == 0)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpGet("GetTransactionStatus")]
        public async Task<IActionResult> GetTransactionStatus(string transactionReference)
        {
            try
            {
                var response = await _bankOpt.GetTransactionStatus(transactionReference);

                if (response.State == 0)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}
