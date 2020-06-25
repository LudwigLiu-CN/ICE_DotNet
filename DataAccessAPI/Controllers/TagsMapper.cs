using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{

    public class TagsMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public Tags SelectByPrimaryKey(int tagId)
        {
            Tags target = iceContext_.Tags.Find(tagId);
            return target;
        }

        public void DeleteByPrimaryKey(int tagId)
        {
            Tags target = iceContext_.Tags.Find(tagId);
            iceContext_.Tags.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(Tags tag)
        {
            iceContext_.Tags.Add(tag);
            iceContext_.SaveChanges();
        }

        public ArrayList SelectAll()
        {
            var targets = from t in iceContext_.Tags select t;
            ArrayList results = new ArrayList();
            foreach(var t in targets)
            {
                results.Add(t);
            }
            return results;
        }

        public void updateByPrimaryKey(Tags tag)
        {
            iceContext_.Tags.Update(tag);
            iceContext_.SaveChanges();
        }
    }
}
