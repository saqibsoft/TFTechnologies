using System;
using System.Collections.Generic;

namespace TFTechnologies.Models
{
    public partial class TicketsType
    {
        public TicketsType()
        {
            Tickets = new HashSet<Tickets>();
        }

        public short TypeId { get; set; }
        public string TypeTitle { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
