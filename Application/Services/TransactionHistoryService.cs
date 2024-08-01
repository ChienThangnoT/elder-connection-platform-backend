using Application.Common;
using Application.Exceptions;
using Application.IServices;
using Application.Library;
using Application.ResponseModels;
using Application.ViewModels.TransactionHistoryViewModels;
using AutoMapper;
using Domain.Enums.TransactionHistoryEnums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Application.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVnpayService _vnpayService;
        private readonly IConfiguration _configuration;
        private readonly PayOSService _payOSService;

        public TransactionHistoryService(IUnitOfWork unitOfWork, IMapper mapper, IVnpayService vnpayService, PayOSService payOSService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vnpayService = vnpayService;
            _configuration = configuration;
            _payOSService = payOSService;
        }

        #region Get Transaction History By Account Id 
        public async Task<BaseResponseModel> GetAllTransactionHistoryByAccountIdAsync
            (string id, int pageIndex = 0, int pageSize = 10)
        {
            var exsitedUser = await _unitOfWork.AccountRepo.GetAccountByIdAsync(id)
                ?? throw new NotExistsException();

            var transactionHistoryList = await _unitOfWork.TransactionHistoryRepo.
                GetTransactionHistoryByAccountIdAsync(id, pageIndex, pageSize);

            var result = _mapper.Map<Pagination<TransactionHistoryViewModel>>(transactionHistoryList);

            var item = result.Items;

            if (item.Count == 0)
            {
                throw new NotExistsException();
            }

            return new SuccessResponseModel
            {
                Status = StatusCodes.Status200OK,
                Message = "Get all transaction by account id success",
                Result = result
            };

        }
        #endregion

        #region Get Transaction By Id
        public async Task<TransactionHistory> GetTransactionById(int id)
        {
            return await _unitOfWork.TransactionHistoryRepo.GetByIdAsync(id) ?? throw new NotExistsException();
        }
        #endregion

        #region Request to up wallet
        public async Task<BaseResponseModel> RequestTopUpWalletAsync(string accountId, float amount, HttpContext context)
        {
            var accountExits = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId)
               ?? throw new NotExistsException();
            TransactionModel transaction = new TransactionModel
            {
                AccountId = accountId,
                AccountName = accountExits.UserName,
                TransactionAmount = amount,
                WalletBalanceChange = amount,
                CurrentWallet = accountExits.WalletBalance,
                PaymentMethod = TransactionMethod.VNPAY.ToString(),
                PaymentDate = DateTime.UtcNow,
                TransactionType = Transactiontype.NAP_TIEN.ToString(),
                CurrencyCode = "VND",
                Status = (int)TransactionStatus.Pending
            };
            var transmodel = _mapper.Map<TransactionHistory>(transaction);

            await _unitOfWork.TransactionHistoryRepo.AddAsync(transmodel);
            await _unitOfWork.SaveChangesAsync();

            VnPaymentRequestModel vnModel = new VnPaymentRequestModel
            {
                Amount = amount,
                CreatedDate = DateTime.UtcNow,
                Description = Transactiontype.NAP_TIEN.ToString(),
                OrderId = transmodel.TransactionId,
                FullName = accountExits.UserName
            };

            var paymentUrl = _vnpayService.CreatePaymentURL(context, vnModel);
            if (paymentUrl != null)
            {
                return new PaymentSuccessResponseModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create payment url success",
                    Result = paymentUrl,
                    transId = transmodel.TransactionId
                };
            }
            return new FailedResponseModel
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Create URL failed"
            };

        }
        #endregion 


        #region Request to up wallet with payos
        public async Task<BaseResponseModel> RequestTopUpWalletWithPayOsAsync(string accountId, float amount)
        {
            var accountExits = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId)
               ?? throw new NotExistsException();
            TransactionModel transaction = new TransactionModel
            {
                AccountId = accountId,
                AccountName = accountExits.UserName,
                TransactionAmount = amount,
                WalletBalanceChange = amount,
                CurrentWallet = accountExits.WalletBalance,
                PaymentMethod = TransactionMethod.VietQR.ToString(),
                PaymentDate = DateTime.UtcNow,
                TransactionType = Transactiontype.NAP_TIEN.ToString(),
                CurrencyCode = "VND",
                Status = (int)TransactionStatus.Pending
            };
            var transmodel = _mapper.Map<TransactionHistory>(transaction);

            await _unitOfWork.TransactionHistoryRepo.AddAsync(transmodel);
            await _unitOfWork.SaveChangesAsync();
            var orderId = transmodel.TransactionId;
            var items = new List<ItemData>
            {
                new ItemData("NẠP TIỀN VÀO HỆ THỐNG", 1, (int)amount)
            };

            long orderCode = long.Parse(DateTimeOffset.Now.ToString("yyMMddHHmmss"));
            string returnUrl = $"https://elderconnection.vercel.app/success?transactionId={orderId}";
            string cancelUrl = $"https://elderconnection.vercel.app/cancel?transactionId={orderId}";


            var payOSModel = new PaymentData(
                orderCode: orderCode,
                amount: (int)amount,
                description: "Thanh toan don hang",
                items: items,
                returnUrl: returnUrl,
                cancelUrl: cancelUrl
            );


            var paymentUrl = await _payOSService.CreatePaymentLink(payOSModel);


            if (paymentUrl != null)
            {
                return new PaymentSuccessResponseModel
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create payment url success",
                    Result = paymentUrl.checkoutUrl,
                    transId = transmodel.TransactionId
                };
            }
            return new FailedResponseModel
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Create URL failed"
            };

        }
        #endregion

        #region Request Deposit To Wallet
        public async Task<BaseResponseModel> RequestDepositToWalletWithPayOs(int transactionId, string status)
        {
            var trans = await GetTransactionById(transactionId);
            var getAccount = await _unitOfWork.AccountRepo.GetAccountByIdAsync(trans.AccountId);
            if (status.ToUpper() == "PAID")
            {
                trans.CurrentWallet += (float)trans.TransactionAmount;
                trans.TransactionNo = DateTimeOffset.Now.ToString("yyMMddHHmmss");
                trans.Status = (int)TransactionStatus.Success;
                trans.PaymentDate = DateTime.UtcNow;
                _unitOfWork.TransactionHistoryRepo.Update(trans);
                getAccount.WalletBalance += trans.TransactionAmount;
                _unitOfWork.AccountRepo.Update(getAccount);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<TransactionHistoryViewModel>(trans);

                return new SuccessResponseModel
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Deposit To Wallet Success",
                    Result = result
                };
                
            }
            else
            {
                trans.PaymentDate = DateTime.UtcNow;
                trans.Status = (int)TransactionStatus.Failed;
                _unitOfWork.TransactionHistoryRepo.Update(trans);
                await _unitOfWork.SaveChangesAsync();
                return new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Payment faild"
                };
            }

        }
        #endregion

        //#region Request Deposit To Wallet
        //public async Task<BaseResponseModel> RequestDepositToWallet(string accountId, int transId, Dictionary<string, StringValues> collections)
        //{
        //    var accountExits = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId)
        //       ?? throw new NotExistsException();

        //    var vnp_BankTranNo = collections.FirstOrDefault(r => r.Key == "vnp_BankTranNo").Value.ToString();


        //    var checkResult = _vnpayService.PaymentExcute(collections);
        //    if (checkResult.Success != false)
        //    {
        //        var trans = await GetTransactionById(transId);
        //        trans.TransactionNo = vnp_BankTranNo;
        //        trans.Status = (int)TransactionStatus.Success;
        //        trans.PaymentDate = DateTime.UtcNow;
        //        _unitOfWork.TransactionHistoryRepo.Update(trans);
        //        accountExits.WalletBalance += trans.TransactionAmount;
        //        _unitOfWork.AccountRepo.Update(accountExits);
        //        await _unitOfWork.SaveChangesAsync();
        //        var result = _mapper.Map<TransactionHistoryViewModel>(trans);

        //        return new SuccessResponseModel
        //        {
        //            Status = StatusCodes.Status200OK,
        //            Message = "Deposit To Wallet Success",
        //            Result = result
        //        };
        //    }
        //    return new FailedResponseModel
        //    {
        //        Status = StatusCodes.Status400BadRequest,
        //        Message = "Payment faild"
        //    };
        //    #endregion
        //}


        #region Request Deposit To Wallet
        public async Task<BaseResponseModel> RequestDepositToWallet_v2(VnPayModel vnPayModel)
        {
            var vnp_BankTranNo = vnPayModel.vnp_BankTranNo;
            var transId = int.Parse(vnPayModel.vnp_OrderInfo);
            var trans = await GetTransactionById(transId);
            var checkResult = _vnpayService.PaymentExcute_v2(vnPayModel);
            var getAccount = await _unitOfWork.AccountRepo.GetAccountByIdAsync(trans.AccountId);

            if (checkResult.Success != false)
            {
                if (checkResult.VnPayResponseCode.Equals("00"))
                {
                    trans.CurrentWallet += (float)vnPayModel.vnp_Amount;
                    trans.TransactionNo = vnp_BankTranNo;
                    trans.Status = (int)TransactionStatus.Success;
                    trans.PaymentDate = DateTime.UtcNow;
                    _unitOfWork.TransactionHistoryRepo.Update(trans);
                    getAccount.WalletBalance += trans.TransactionAmount;
                    _unitOfWork.AccountRepo.Update(getAccount);
                    await _unitOfWork.SaveChangesAsync();
                    var result = _mapper.Map<TransactionHistoryViewModel>(trans);

                    return new SuccessResponseModel
                    {
                        Status = StatusCodes.Status200OK,
                        Message = "Deposit To Wallet Success",
                        Result = result
                    };
                }
                trans.PaymentDate = DateTime.UtcNow;
                trans.Status = (int)TransactionStatus.Failed;
                _unitOfWork.TransactionHistoryRepo.Update(trans);
                await _unitOfWork.SaveChangesAsync();
                return new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Payment faild"
                };
            }
            else
            {
                return new FailedResponseModel
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Payment faild"
                };
            }

        }
        #endregion

        #region Create transaction for service payment
        public async Task<bool> CreateTransasctionForService(string accountId, float amount)
        {
            var accountExits = await _unitOfWork.AccountRepo.GetAccountByIdAsync(accountId)
              ?? throw new NotExistsException();
            TransactionModel transaction = new TransactionModel
            {
                AccountId = accountId,
                AccountName = accountExits.UserName,
                TransactionAmount = amount,
                WalletBalanceChange = amount,
                CurrentWallet = accountExits.WalletBalance,
                PaymentMethod = TransactionMethod.SYSTEM.ToString(),
                PaymentDate = DateTime.UtcNow,
                TransactionType = Transactiontype.THANH_TOAN.ToString(),
                CurrencyCode = "VND",
                Status = (int)TransactionStatus.Success
            };
            var transmodel = _mapper.Map<TransactionHistory>(transaction);

            await _unitOfWork.TransactionHistoryRepo.AddAsync(transmodel);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        #endregion



    }
}
