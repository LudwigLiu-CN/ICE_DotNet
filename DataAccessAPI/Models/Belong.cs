using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class Belong
    {
        public int GameId { get; set; }
        public int CateId { get; set; }

        public virtual Categories Cate { get; set; }
        public virtual Games Game { get; set; }
    }
}
