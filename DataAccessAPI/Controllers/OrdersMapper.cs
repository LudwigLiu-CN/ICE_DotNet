using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/OrdersMapper/deleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int orderId)
        {
            var t = iceContext_.Orders.FirstOrDefault(m => m.OrderId == orderId);
            if (t != null)
            {
                iceContext_.Orders.Remove(t);
                iceContext_.SaveChanges();
            }
        }

        [Route("/OrdersMapper/Insert")]
        [HttpGet]
        public void Insert(Orders order)
        {
            iceContext_.Orders.Add(order);
            iceContext_.SaveChanges();
        }

        public Orders SelectByPrimaryKey(int orderId)
        {
            Orders orders = iceContext_.Orders.Find(orderId);
            return orders;
        }

        public void UpdateByPrimaryKey(Orders record)
        {
            iceContext_.Orders.Update(record);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKeySelective(Orders order)
        {
            Orders target = iceContext_.Orders.Find(order.OrderId);
            if(order.Date != null)
            {
                target.Date = order.Date;
            }
            if (order.ConsoleId != null)
            {
                target.ConsoleId = order.ConsoleId;
            }
            if (order.Address != null)
            {
                target.Address = order.Address;
            }
            if (order.ContactTel != null)
            {
                target.ContactTel = order.ContactTel;
            }
            if (order.Status != null)
            {
                target.Status = order.Status;
            }
            if (order.UserId != 0)
            {
                target.UserId = order.UserId;
            }
            if (order.GameId != 0)
            {
                target.GameId = order.GameId;
            }
            if (order.Price != null)
            {
                target.Price = order.Price;
            }
            iceContext_.Orders.Update(record);
            iceContext_.SaveChanges();
        }
        [Route("/OrdersMapper/orderNumOf")]
        [HttpGet]
        public int OrderNumOf(int userId)
        {
            var num = (from o in iceContext_.Orders where o.UserId == userId select o).Count();
            return num;
        }

        [Route("/OrdersMapper/selectByPublisherId")]
        [HttpGet]
        public List<Orders> SelectByPublishierId(int publisherId)
        {
            var targets = from o in iceContext_.Orders
                          join s in iceContext_.SaleGame on o.GameId equals s.GameId
                          where s.PublisherId == publisherId
                          select o;
            List<Orders> results = new List<Orders>();
            foreach (var t in targets)
            {
                //Console.WriteLine(t);
           
                results.Add(t);
            }
            return results;
        }

        //需要加入game

        [Route("/OrdersMapper/selectByUserId")]
        [HttpGet]
        public List<Orders> SelectByUserId(int userId)
        {
            var targets = from o in iceContext_.Orders
                          join s in iceContext_.SaleGame on o.GameId equals s.GameId
                          where o.UserId == userId
                          select o;
            List<Orders> results = new List<Orders>();
            foreach (var t in targets)
            {
                //var game = iceContext_.SaleGame.First(m => m.GameId == t.GameId);
                //t.Game = game.Game;
                //var game = from s in iceContext_.SaleGame where s.GameId == t.GameId select
                results.Add(t);
            }
            return results;
        }
    }
}
