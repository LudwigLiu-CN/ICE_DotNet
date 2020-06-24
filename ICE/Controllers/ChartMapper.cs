using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Contexts;
using ICE.Models;
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
            //var targets = from ch in iceContext_.Chart join ga in iceContext_.Games join pl in iceContext_.PlayedOn join co in iceContext_.Consoles join be in iceContext_.Belong join ca in iceContext_.Categories on ch.GameId == ga.GameId and ch
            ArrayList results = new ArrayList();
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
