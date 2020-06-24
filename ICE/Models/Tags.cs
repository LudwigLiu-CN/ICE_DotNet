using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Tags
    {
        public Tags()
        {
            HasTag = new HashSet<HasTag>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<HasTag> HasTag { get; set; }
    }
}
