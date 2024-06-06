using Application.ResponseModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVnpayService
    {
        string CreatePaymentURL(HttpContent content, VnPaymentRequestModel vnPaymentRequestModel);

        VnPaymentResponseModel PaymentExcute(IQueryCollection collections);
    }
}
