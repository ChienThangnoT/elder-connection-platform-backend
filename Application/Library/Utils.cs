using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Application.Library
{
    public class Utils
    {
        public static string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        public static string GetIpAddress(HttpContext context)
        {
            string ipAddress = string.Empty;

            try
            {
                ipAddress = context.Connection.RemoteIpAddress?.ToString();

                if (string.IsNullOrEmpty(ipAddress) && context.Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    ipAddress = context.Request.Headers["X-Forwarded-For"].ToString().Split(',')[0];
                }

                if (string.IsNullOrEmpty(ipAddress) && context.Request.Headers.ContainsKey("X-Real-IP"))
                {
                    ipAddress = context.Request.Headers["X-Real-IP"].ToString();
                }
            }
            catch (Exception ex)
            {
                ipAddress = "Unable to determine IP address";
            }

            return ipAddress;
        }
    }
}
