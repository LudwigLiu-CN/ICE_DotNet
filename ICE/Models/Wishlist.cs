using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Wishlist
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public bool? Notification { get; set; }

        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
