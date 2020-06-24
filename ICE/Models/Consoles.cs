using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Consoles
    {
        public Consoles()
        {
            Orders = new HashSet<Orders>();
            PlayedOn = new HashSet<PlayedOn>();
        }

        public int ConsoleId { get; set; }
        public string ConsoleName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PlayedOn> PlayedOn { get; set; }
    }
}
