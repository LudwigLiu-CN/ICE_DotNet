using DataAccessAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameManageService
{
    class GameManager
    {
        public int game_id { get; set; }
        public String title { get; set; }
        public float price { get; set; }
        public bool discount { get; set; }
        public float average_rate { get; set; }
        public DateTime release_date { get; set; }
        public bool pre_order { get; set; }
        public int rate_count { get; set; }
        public String cover { get; set; }
        public String description { get; set; }
        public bool on_sale { get; set; }

        public Categories category { get; set; }

        public List<Tags> tags_list { get; set; }
        public List<String> pictures { get; set; }
        public List<Consoles> consoles { get; set; }

       

    }
}
