﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Library
{
    public class VnPayModel
    {
        public string vnp_TmnCode { get; set; } = string.Empty;
        public string vnp_BankCode { get; set; } = string.Empty;
        public string? vnp_BankTranNo { get; set; } = string.Empty;
        public string vnp_CardType { get; set; } = string.Empty;
        public string vnp_OrderInfo { get; set; } = string.Empty;
        public string vnp_TransactionNo { get; set; } = string.Empty;
        public string vnp_TransactionStatus { get; set; } = string.Empty;
        public string vnp_TxnRef { get; set; } = string.Empty;
        public string? vnp_SecureHashType { get; set; } = string.Empty;
        public string vnp_SecureHash { get; set; } = string.Empty;
        public int? vnp_Amount { get; set; }
        public string? vnp_ResponseCode { get; set; }
        public string vnp_PayDate { get; set; } = string.Empty;

        public string ToUrlParameters()
        {
            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var queryString = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                if (value != null)
                {
                    queryString.Add($"{property.Name}={HttpUtility.UrlEncode(value.ToString())}");
                }
            }

            return string.Join("&", queryString);
        }
    }
}
