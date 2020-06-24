using System;
using System.Collections.Generic;

namespace ICE.Models
{
    public partial class Publishers
    {
        public Publishers()
        {
            SaleGame = new HashSet<SaleGame>();
        }

        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public string LogoPath { get; set; }
        public string Pwd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SaleGame> SaleGame { get; set; }
    }
}
