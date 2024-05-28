using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums.AddressEnums
{
    public enum HomeType
    {
        [Description("Townhouse")]
        Townhouse = 1,
        [Description("Apartment")]
        Apartment = 2,
        [Description("Mansion")]
        Mansion = 3
    }
}
