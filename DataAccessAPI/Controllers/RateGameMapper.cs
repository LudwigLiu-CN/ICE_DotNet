using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    public class RateGameMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        public void Insert(RateGame target)
        {
            iceContext_.RateGame.Add(target);
            iceContext_.SaveChanges();
        }

        public void SubmitRate(int UserId, int GameId, int Rate)
        {
            RateGame target = new RateGame();
            target.UserId = UserId;
            target.GameId = GameId;
            target.Rate = Rate;
            iceContext_.RateGame.Add(target);
            iceContext_.SaveChanges();
        }

        public double GetAverage(int GameId)
        {
            var targets = from r in iceContext_.RateGame where r.GameId == GameId select r.Rate;
            double sum = 0;
            int num = 0;
            foreach(var r in targets)
            {
                sum += Convert.ToDouble(r);
                num++;
            }
            double AvgRate = sum / num;
            return AvgRate;
        }

        public int? MyRate(int GameId, int UserId)
        {
            var target = from r in iceContext_.RateGame where r.GameId == GameId && r.UserId == UserId select r.Rate;
            return target.First();
        }
    }
}
