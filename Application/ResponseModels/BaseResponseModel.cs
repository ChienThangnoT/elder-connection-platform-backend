using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        public object? Result { get; set; }
    }  
    public class TokenModel : BaseResponseModel
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public string? ConfirmEmailToken { get; set; }
    }
}
