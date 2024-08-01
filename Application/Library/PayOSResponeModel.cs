using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Library
{
    public class PayOSResponeModel
    {
        public int transactionId {  get; set; }
        public int code { get; set; }
        public string? id { get; set; }
        public bool cancel { get; set; }
        public string? status { get; set; }
        public long orderCode {  get; set; }
    }
}
