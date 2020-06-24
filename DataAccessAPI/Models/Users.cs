using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Chart = new HashSet<Chart>();
            Orders = new HashSet<Orders>();
            RateGame = new HashSet<RateGame>();
            Wishlist = new HashSet<Wishlist>();
            WriteReview = new HashSet<WriteReview>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Tel { get; set; }
        public string AvatarPath { get; set; }
        public string Address { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Chart> Chart { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<RateGame> RateGame { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<WriteReview> WriteReview { get; set; }
    }
}
