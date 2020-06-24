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
    [Route("api/[controller")]
    public class GamesMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/GamesMapper/SelectByPrimaryKey")]
        [HttpGet]
        public Games SelectByPrimaryKey(int GameId)
        {
            Games target = iceContext_.Games.Find(GameId);
            return target;
        }

        [Route("/GamesMapper/DeleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int GameId)
        {
            Games target = iceContext_.Games.Find(GameId);
            iceContext_.Games.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Games target)
        {
            iceContext_.Games.Add(target);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Games update)
        {
            iceContext_.Games.Update(update);
            iceContext_.SaveChanges();
        }

        public void UpdatePrimaryKeySelective(Games update)
        {
            Games target = iceContext_.Games.Find(update.GameId);
            if (update.Title != null)
            {
                target.Title = update.Title;
            }
            if (update.Price != null)
            {
                target.Price = update.Price;
            }
            if (update.CoverPath != null)
            {
                target.CoverPath = update.CoverPath;
            }
            if (update.Discount != null)
            {
                target.Discount = update.Discount;
            }
            if (update.AverageRate != null)
            {
                target.AverageRate = update.AverageRate;
            }
            if (update.ReleaseDate != null)
            {
                target.ReleaseDate = update.ReleaseDate;
            }
            if (update.PreOrder != null)
            {
                target.PreOrder = update.PreOrder;
            }
            if (update.RateCount != null)
            {
                target.RateCount = update.RateCount;
            }
            if (update.Description != null)
            {
                target.Description = update.Description;
            }
            if (update.OnSale != null)
            {
                target.OnSale = update.OnSale;
            }
            iceContext_.Games.Update(target);
            iceContext_.SaveChanges();
        }
        
        [Route("/GamesMapper/GetAll")]
        [HttpGet]
        public ArrayList GetAll()
        {
            var targets = from g in iceContext_.Games select g;
            ArrayList results = new ArrayList();
            foreach(var g in targets)
            {
                results.Add(g);
            }
            return results;
        }

        [Route("/GamesMapper/SearchByTitle")]
        [HttpGet]
        public ArrayList SearchByTitle(string KeyWords)
        {
            var targets = from g in iceContext_.Games where g.Title.Contains(KeyWords) select g;
            ArrayList results = new ArrayList();
            foreach(var g in targets)
            {
                results.Add(g);
            }
            return results;
        }
    }
}
