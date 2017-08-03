using System;
using System.Collections.Generic;

namespace TFTechnologies.Models
{
    public partial class Tickets
    {
        public long TicketId { get; set; }
        public short TypeId { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }
        public string MsgDetail { get; set; }
        public DateTime EntryDate { get; set; }
        public byte Status { get; set; }
        public long? ReplyId { get; set; }
        public long ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Tickets Reply { get; set; }
        public virtual ICollection<Tickets> InverseReply { get; set; }
        public virtual TicketsType Type { get; set; }
        public virtual WebUser User { get; set; }
    }
}
