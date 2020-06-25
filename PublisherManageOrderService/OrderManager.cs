using DataAccessAPI.Models;
using System;

namespace PublisherManageOrderService
{
    public class OrderManager
    {
        public int order_id{get;set;}
        public DateTime order_date {get;set;}
        public String address{get;set;}
        public Consoles console{get;set;}
        public String contact_tel{get;set;}
        public int status{get;set;}
        public float price{get;set;}

        public int user_id{get;set;}
        public String user_name{get;set;}

        public int game_id{get;set;}
        public String game_name{get;set;}
    }
}