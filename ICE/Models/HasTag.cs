using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class HasTag
    {
        public int GameId { get; set; }
        public int TagId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
