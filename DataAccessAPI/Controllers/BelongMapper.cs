using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessAPI.Controllers
{
    public class BelongMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        public Belong SelectByPrimaryKey(int GameId)
        {
            Belong target = iceContext_.Belong.Find(GameId);
            return target;
        }

        public void DeleteByPrimaryKey(int GameId)
        {
            Belong target = iceContext_.Belong.Find(GameId);
            iceContext_.Belong.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Belong target)
        {
            iceContext_.Belong.Add(target);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Belong update)
        {
            iceContext_.Belong.Update(update);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKeySelective(Belong update)
        {
            Belong target = iceContext_.Belong.Find(update.GameId);
            if (update.CateId != null)
            {
                target.CateId = update.CateId;
            }
            iceContext_.Update(target);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectByCateId(int CateId)
        {
            var targets = from b in iceContext_.Belong where b.CateId == CateId select b;
            ArrayList results = new ArrayList();
            foreach(var b in targets)
            {
                results.Add(b);
            }
            return results;
        }
    }
}
