using Application.IServices;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VnpayService : IVnpayService
    {
        private readonly IConfiguration _configuration;

        public VnpayService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreatePaymentURL(HttpContent content, VnPaymentRequestModel vnPaymentRequestModel)
        {
            throw new NotImplementedException();
        }

        public VnPaymentResponseModel PaymentExcute(IQueryCollection collections)
        {
            throw new NotImplementedException();
        }
    }
}
