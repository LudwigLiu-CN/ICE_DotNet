using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class Games
    {
        public Games()
        {
            Chart = new HashSet<Chart>();
            HasReview = new HashSet<HasReview>();
            HasTag = new HashSet<HasTag>();
            Orders = new HashSet<Orders>();
            PlayedOn = new HashSet<PlayedOn>();
            RateGame = new HashSet<RateGame>();
            SaleGame = new HashSet<SaleGame>();
            Wishlist = new HashSet<Wishlist>();
        }

        public int GameId { get; set; }
        public string Title { get; set; }
        public float? Price { get; set; }
        public string CoverPath { get; set; }
        public bool? Discount { get; set; }
        public float? AverageRate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? PreOrder { get; set; }
        public int? RateCount { get; set; }
        public bool? OnSale { get; set; }
        public string Description { get; set; }

        public virtual Belong Belong { get; set; }
        public virtual ICollection<Chart> Chart { get; set; }
        public virtual ICollection<HasReview> HasReview { get; set; }
        public virtual ICollection<HasTag> HasTag { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PlayedOn> PlayedOn { get; set; }
        public virtual ICollection<RateGame> RateGame { get; set; }
        public virtual ICollection<SaleGame> SaleGame { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
