using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class WriteReview
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }

        public virtual Reviews Review { get; set; }
        public virtual Users User { get; set; }
    }
}
