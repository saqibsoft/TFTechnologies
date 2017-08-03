using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFTechnologies.Models;

namespace TFTechnologies.ViewModels
{
    public class Tasks
    {
        public long TicketId { get; set; }
        public TicketsType TypeId { get; set; }
        public long UserId { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }
        public string MsgDetail { get; set; }
        public DateTime EntryDate { get; set; }
        public byte Status { get; set; }
        public long? ReplyId { get; set; }
        public long ProductId { get; set; }

        //public virtual Products Product { get; set; }
        //public virtual Tickets Reply { get; set; }
        //public virtual ICollection<Tickets> InverseReply { get; set; }
        //public virtual TicketsType Type { get; set; }
        //public virtual WebUser User { get; set; }

    }
}
