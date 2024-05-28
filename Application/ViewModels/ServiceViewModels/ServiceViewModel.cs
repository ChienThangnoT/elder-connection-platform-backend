using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ServiceViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public int ServiceTypeId { get; set; }
        public int SaleId { get; set; }
        public float OriginalPrice { get; set; }
        public float FinalPrice { get; set; }
        public string? ServiceTypeHours { get; set; }
        public string? ServiceDescription { get; set; }
        public float RatingAvg { get; set; }
    }
}
