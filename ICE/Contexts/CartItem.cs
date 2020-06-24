using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class CartItem
    {
        public int GameId { get; set; }
        public String title { get; set; }
        public float? price { get; set; }
        public String coverPath { get; set; }
        public bool? discount { get; set; }
        public String consoleName { get; set; }
        public int consoleId { get; set; }
        public int cateId { get; set; }
        public String cateName { get; set; }
    }
}
