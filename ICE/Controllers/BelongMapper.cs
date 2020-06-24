using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Contexts;
using ICE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BelongMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/BelongMapper/SelectByPrimaryKey")]
        [HttpGet]
        public Belong SelectByPrimaryKey(int GameId)
        {
            Belong target = iceContext_.Belong.Find(GameId);
            return target;
        }

        [Route("/BelongMapper/DeleteByPrimaryKey")]
        [HttpGet]
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

        [Route("/BelongMapper/SelectByCateId")]
        [HttpGet]
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
