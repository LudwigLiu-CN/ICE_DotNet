using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class HasReview
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Reviews Review { get; set; }
    }
}
