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
    public class ConsolesMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/ConsolesMapper/SelectByPrimaryKey")]
        [HttpGet]
        public Consoles SelectByPrimaryKey(int ConsoleId)
        {
            Consoles target = iceContext_.Consoles.Find(ConsoleId);
            return target;
        }

        [Route("/ConsolesMapper/DeleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int ConsoleId)
        {
            Consoles target = iceContext_.Consoles.Find(ConsoleId);
            iceContext_.Consoles.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Consoles target)
        {
            iceContext_.Consoles.Add(target);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Consoles update)
        {
            iceContext_.Consoles.Update(update);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKeySelective(Consoles update)
        {
            Consoles target = iceContext_.Consoles.Find(update.ConsoleId);
            if (update.ConsoleName != null)
            {
                target.ConsoleName = update.ConsoleName;
            }
            iceContext_.Consoles.Update(target);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectAll()
        {
            var targets = from b in iceContext_.Consoles select b;
            ArrayList results = new ArrayList();
            foreach(var b in targets)
            {
                results.Add(b);
            }
            return results;
        }
    }
}
