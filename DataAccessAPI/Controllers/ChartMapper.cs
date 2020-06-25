using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    public class ChartMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/ChartMapper/DeleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int GameId, int UserId)
        {
            Chart target = iceContext_.Chart.Find(GameId, UserId);
            iceContext_.Chart.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Chart target)
        {
            iceContext_.Chart.Add(target);
            iceContext_.SaveChanges();
        }

        public int ChartNumOf(int UserId)
        {
            var targets = from b in iceContext_.Chart where b.UserId == UserId select b;
            int num = 0;
            foreach (var b in targets)
            {
                num++;
            }
            return num;
        }

        public ArrayList GetMyCart(int UserId, int StartWith, int EndWith, int Reverse)
        {
            var targets = from c in iceContext_.Chart
                          join g in iceContext_.Games on c.GameId equals g.GameId
                          join console in iceContext_.Consoles on c.ConsoleId equals console.ConsoleId
                          where c.UserId == UserId
                          select new
                          {
                              game_id = g.GameId,
                              title = g.Title,
                              price = g.Price,
                              coverPath = g.CoverPath,
                              discount = g.Discount,
                              consoleName = console.ConsoleName,
                              consoleId = console.ConsoleId
                          };
            ArrayList results = new ArrayList();
            foreach (var c in targets)
            {
                CartItem cartItem = new CartItem();
                cartItem.GameId = c.game_id;
                cartItem.title = c.title;
                cartItem.price = c.price;
                cartItem.coverPath = c.coverPath;
                cartItem.discount = c.discount;
                cartItem.consoleName = c.consoleName;
                cartItem.consoleId = c.consoleId;
                results.Add(cartItem);
            }
            return results;
        }


        public void AddToCart(int UserId, int GameId, int ConsoleId)
        {
            Chart target = new Chart();
            target.UserId = UserId;
            target.GameId = GameId;
            target.ConsoleId = ConsoleId;
            iceContext_.Chart.Add(target);
            iceContext_.SaveChanges();
        }
    }
}
