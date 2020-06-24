using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public string Address { get; set; }
        public int ConsoleId { get; set; }
        public string ContactTel { get; set; }
        public int? Status { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public float? Price { get; set; }

        public virtual Consoles Console { get; set; }
        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
