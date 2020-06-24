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
            ConsolesMapper consolesMapper = new ConsolesMapper();
            var targets = from c in iceContext_.Chart where c.UserId == UserId select c;
            ArrayList results = new ArrayList();
            foreach(var c in targets)
            {
                CartItem cartItem = new CartItem();
                cartItem.GameId = c.Game.GameId;
                cartItem.title = c.Game.Title;
                cartItem.price = c.Game.Price;
                cartItem.coverPath = c.Game.CoverPath;
                cartItem.discount = c.Game.Discount;
                cartItem.consoleName = consolesMapper.SelectByPrimaryKey(c.ConsoleId).ConsoleName;
                cartItem.consoleId = c.ConsoleId;
                cartItem.cateId = c.Game.Belong.CateId;
                cartItem.cateName = c.Game.Belong.Cate.CateName;
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
