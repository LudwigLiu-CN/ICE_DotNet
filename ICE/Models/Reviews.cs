using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Reviews
    {
        public Reviews()
        {
            HasReview = new HashSet<HasReview>();
        }

        public int ReviewId { get; set; }
        public string Content { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual WriteReview WriteReview { get; set; }
        public virtual ICollection<HasReview> HasReview { get; set; }
    }
}
