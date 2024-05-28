using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ServiceTypeViewModels
{
    public class DetailServiceTypeModel
    {
        public int ServiceTypeId { get; set; }

        public string? ServiceTypeName { get; set; }

        public float ServicePricePerHour { get; set; }
    }
}
