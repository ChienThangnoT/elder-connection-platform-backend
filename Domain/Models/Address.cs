using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string? CustomerId { get; set; }
        public string? ConnectorId { get; set; }
        public string? AddressName { get; set; }
        public string? AddressDetail { get; set; }
        public string? AddressDescription { get; set; }
        public string? HomeType { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }

        public virtual Account? Customer { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
