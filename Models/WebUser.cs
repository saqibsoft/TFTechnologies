using System;
using System.Collections.Generic;

namespace TFTechnologies.Models
{
    public partial class WebUser
    {
        public WebUser()
        {
            Tickets = new HashSet<Tickets>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
