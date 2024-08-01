using Application;
using Application.Exceptions;
using Application.IServices;
using Application.ResponseModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElderConnectionPlatform.API.Controllers
{
    [Route("api/transaction-histories")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionHistoryService _transactionHistoryService;

        public TransactionHistoryController(IUnitOfWork unitOfWork, ITransactionHistoryService transactionHistoryService)
        {
            _unitOfWork = unitOfWork;
            _transactionHistoryService = transactionHistoryService;
        }

        [HttpGet("get-all-transaction-history-by-account/{accountId}")]
        public async Task<IActionResult> GetAllTransactionHistoryByAccountId
            (string accountId, int pageIndex = 0, int pageSize = 10)
        {
            var result = await _transactionHistoryService
                .GetAllTransactionHistoryByAccountIdAsync(accountId, pageIndex, pageSize);
            return Ok(result);
        }

        #region Get All Transactions
        [HttpGet("get-all-transactions")]
        public async Task<IActionResult> GetAllTransactionAsync(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var transactionsList = await _transactionHistoryService.GetAllTransactionAsync(pageIndex, pageSize);

                if (transactionsList == null)
                {
                    throw new NotExistsException();
                }

                return (transactionsList.Items.Count == 0) ?
                    NoContent()
                    :
                    Ok(new SuccessResponseModel
                    {
                        Status = StatusCodes.Status200OK,
                        Message = "Succeed.",
                        Result = transactionsList
                    });
            }
            catch (ArgumentException ex)
            {
                // return status code bad request for validation
                return BadRequest(new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Invalid parameters.",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
