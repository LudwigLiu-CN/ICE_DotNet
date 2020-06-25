using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAccess.Controllers
{

    public class SaleGameMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public SaleGame SelectByPrimaryKey(int PublisherId, int GameId)
        {
            SaleGame target = iceContext_.SaleGame.Find(PublisherId, GameId);
            return target;
        }

        public void DeleteByPrimaryKey(int PublisherId, int GameId)
        {
            SaleGame target = iceContext_.SaleGame.Find(PublisherId, GameId);
            iceContext_.SaleGame.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(SaleGame record)
        {
            iceContext_.SaleGame.Add(record);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectByPublisherId(int PublisherId)
        {
            var targets = from sg in iceContext_.SaleGame where sg.PublisherId == PublisherId select sg;
            ArrayList results = new ArrayList();
            foreach(var sg in targets)
            {
                results.Add(sg);
            }
            return results;
        }

        public ArrayList SelectByGameId(int GameId)
        {
            var targets = from sg in iceContext_.SaleGame where sg.GameId == GameId select sg;
            ArrayList results = new ArrayList();
            foreach (var sg in targets)
            {
                results.Add(sg);
            }
            return results;
        }

        public ArrayList getMaxGameId()
        {
            var target = from sg in iceContext_.SaleGame orderby sg.GameId descending select sg;
            ArrayList results = new ArrayList();
            foreach(var sg in target)
            {
                results.Add(sg);
            }
            return results;
        }
    }
}
