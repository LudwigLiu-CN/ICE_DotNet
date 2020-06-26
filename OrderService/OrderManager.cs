using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService
{
    public class OrderManager
    {
        ConsolesMapper consolesMapper = new ConsolesMapper();
        UserMapper userMapper = new UserMapper();
        GamesMapper gamesMapper = new GamesMapper();

        public int order_id { get; set; }
        public DateTime order_date { get; set; }
        public string address { get; set; }
        public Consoles console { get; set; }
        public string contact_tel { get; set; }
        public int status { get; set; }
        public float price { get; set; }

        public int user_id { get; set; }
        public string user_name { get; set; }
        public int game_id { get; set; }
        public string game_name { get; set; }

        public OrderManager convertToOrderManager(Orders order)
        {
            OrderManager orderManager = new OrderManager();

            orderManager.order_id = order.OrderId;
            orderManager.order_date = (DateTime)order.Date;
            orderManager.address = order.Address;
            orderManager.console = consolesMapper.SelectByPrimaryKey((int)order.ConsoleId);
            orderManager.contact_tel = order.ContactTel;
            orderManager.status = (int)order.Status;
            orderManager.price = (float)order.Price;

            orderManager.user_id = (int)order.UserId;
            orderManager.user_name = userMapper.SelectByPrimaryKey((int)order.UserId).UserName;

            orderManager.game_id = (int)order.GameId;
            orderManager.game_name = gamesMapper.SelectByPrimaryKey((int)order.GameId).Title;

            return orderManager;
        }
    }
}
