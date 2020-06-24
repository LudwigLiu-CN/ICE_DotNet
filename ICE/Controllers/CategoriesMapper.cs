using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICE.Contexts;
using ICE.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/CategoriesMapper/SelectByPrimaryKey")]
        [HttpGet]
        public Categories SelectByPrimaryKey(int CateId)
        {
            Categories target = iceContext_.Categories.Find(CateId);
            return target;
        }

        [Route("/CategoriesMapper/DeleteByPrimaryKey")]
        [HttpGet]
        public void DeletePrimaryKey(int CateId)
        {
            Categories target = iceContext_.Categories.Find(CateId);
            iceContext_.Categories.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Categories target)
        {
            iceContext_.Categories.Add(target);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(Categories update)
        {
            iceContext_.Categories.Update(update);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKeySelective(Categories update)
        {
            Categories target = iceContext_.Categories.Find(update.CateId);
            if (update.CateName != null)
            {
                target.CateName = update.CateName;
            }
            iceContext_.Categories.Update(target);
            iceContext_.SaveChanges();
        }

        [Route("/CategoriesMapper/SelectAll")]
        [HttpGet]
        public ArrayList SelectAll()
        {
            var targets = from b in iceContext_.Categories select b;
            ArrayList results = new ArrayList();
            foreach(var b in targets)
            {
                results.Add(b);
            }
            return results;
        }
    }
}
