using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace Application.ResponseModels
{
    public class BaseResponseModel
    {
        public int Status { get; set; }

        public string Message { get; set; }

    }

    public class FailedResponseModel : BaseResponseModel
    {
        public object? Errors { get; set; }
    }

    public class SuccessResponseModel : BaseResponseModel
    {
        public object? Result { get; set; } = new object();
    }
    public class EmailTokenModel : BaseResponseModel
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public string? ConfirmEmailToken { get; set; }
    }
    
    public class AuthenticationResponseModel : BaseResponseModel
    {
        public string JwtToken { get; set; }
        [Ignore]
        [IgnoreDataMember]
        [JsonIgnore]
        public Task<String>? VerifyEmailToken { get; set; }
        public DateTime? Expired { get; set; }
        public string JwtRefreshToken { get; set; }
        public object? AccountId { get; set; }
    }

    public class PaymentSuccessResponseModel : BaseResponseModel
    {
        public object? Result { get; set; }
        public int transId { get; set; }
    }
}
