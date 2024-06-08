using Application.Library;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVnpayService
    {
        string CreatePaymentURL(HttpContext context, VnPaymentRequestModel vnPaymentRequestModel);

        //VnPaymentResponseModel PaymentExcute(Dictionary<string, StringValues> collections);
        VnPaymentResponseModel PaymentExcute_v2(VnPayModel vnPayModel);
    }
}
