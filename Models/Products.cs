using System;
using System.Collections.Generic;

namespace TFTechnologies.Models
{
    public partial class Products
    {
        public Products()
        {
            Tickets = new HashSet<Tickets>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual Products Product { get; set; }
        public virtual Products InverseProduct { get; set; }
    }
}
