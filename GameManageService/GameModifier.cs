using System;
using System.Collections.Generic;
using System.Text;

namespace GameManageService
{
    public class GameModifier
    {
        public int game_id{get;set;}
        public String title{get;set;}
        public float? price{get;set;}
        public bool? discount{get;set;}
        public bool? pre_order{get;set;}
        public String description{get;set;}
        public List<int> list_console_id{get;set;}

        public GameModifier()
        {
            list_console_id = new List<int>();
        }
    }
}
