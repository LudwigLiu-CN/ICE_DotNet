using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Belong = new HashSet<Belong>();
        }

        public int CateId { get; set; }
        public string CateName { get; set; }

        public virtual ICollection<Belong> Belong { get; set; }
    }
}
