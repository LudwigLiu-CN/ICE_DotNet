using System;
using System.Collections.Generic;

namespace DataAccessAPI.Models
{
    public partial class Chart
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int ConsoleId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Users User { get; set; }
    }
}
