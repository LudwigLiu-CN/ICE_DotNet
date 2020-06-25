using System;
using System.Collections.Generic;
using System.Text;

namespace GameManageService
{
    public class GameAdder
    {
        public String title{get;set;}
        public float price{get;set;}
        public bool discount{get;set;}
        public DateTime release_date{get;set;}
        public bool pre_order{get;set;}
        public String description{get;set;}

        public int cate_id{get;set;}
        public String cover{get;set;}
        public List<int> list_console_id{get;set;}
        public List<int> list_tag_id{get;set;}
        public List<String> pictures{get;set;}

        public GameAdder()
        {
            list_console_id = new List<int>();
            list_tag_id = new List<int>();
            pictures = new List<string>();
        }
    }
}
