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

        private int order_id;
        private DateTime order_date;
        private string address;
        private Consoles console;
        private string contact_tel;
        private int status;
        private float price;

        private int user_id;
        private string user_name;
        private int game_id;
        private string game_name;

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
