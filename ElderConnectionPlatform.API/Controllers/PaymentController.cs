using Application.IServices;
using Application.Library;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;

        public PaymentController(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
        }

        [HttpPost("request-top-up-wallet")]
        public async Task<IActionResult> RequestTopUpWallet(string accountId, float amount)
        {
            try
            {
                var paymenturl = await _transactionHistoryService.RequestTopUpWalletAsync(accountId, amount, HttpContext);
                return Ok(paymenturl);
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid parameters.",
                    Errors = ex.Message
                });
            }

        } 


        [HttpPost("request-top-up-wallet-with-payos")]
        public async Task<IActionResult> RequestTopUpWalletWithPayOs(string accountId, float amount)
        {
            try
            {
                var paymenturl = await _transactionHistoryService.RequestTopUpWalletWithPayOsAsync(accountId, amount);
                return Ok(paymenturl);
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid parameters.",
                    Errors = ex.Message
                });
            }

        }

        //[HttpPost("request-deposit-to-wallet")]
        //public async Task<IActionResult> RequestDepositToWallet( string accountId, int transId,[FromQuery] PaymentQueryModel queryModel)
        //{
        //    try
        //    {
        //        var paymenturl = await _transactionHistoryService.RequestDepositToWallet(accountId, transId,queryModel.ToQueryDictionary());
        //        return Ok(paymenturl);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new FailedResponseModel
        //        {
        //            Status = StatusCodes.Status400BadRequest,
        //            Message = "Invalid parameters.",
        //            Errors = ex.Message
        //        });
        //    }
        //}

        [HttpGet("request-deposit-to-wallet-v2")]
        public async Task<IActionResult> ConfirmRecharge([FromQuery] VnPayModel vnpayResponse)
        {
            try
            {
                var result = await _transactionHistoryService.RequestDepositToWallet_v2(vnpayResponse);

                if (result.Status == 400)
                {
                    
                    return BadRequest(new FailedResponseModel
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Payment faild"
                    });
                }
                return Ok(new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Payment success"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
        
        [HttpGet("request-deposit-to-wallet-with-payos")]
        public async Task<IActionResult> RequestDepositToWalletWithPayOs(int transactionId, string status)
        {
            try
            {
                var result = await _transactionHistoryService.RequestDepositToWalletWithPayOs(transactionId, status);

                if (result.Status == 400)
                {
                    
                    return BadRequest(new FailedResponseModel
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Payment faild"
                    });
                }
                return Ok(new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Payment success"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}
