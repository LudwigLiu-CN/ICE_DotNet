using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteReviewMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public WriteReview SelectByPrimaryKey(int id)
        {
            WriteReview target = iceContext_.WriteReview.Find(id);
            return target;
        }

        public void DeleteByPrimaryKey(int id)
        {
            WriteReview target = iceContext_.WriteReview.Find(id);
            iceContext_.WriteReview.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(WriteReview writeReview)
        {
            iceContext_.WriteReview.Add(writeReview);
            iceContext_.SaveChanges();
        }

        public void UpdateByPrimaryKey(WriteReview writeReview)
        {
            iceContext_.WriteReview.Update(writeReview);
            iceContext_.SaveChanges();
        }
    }
}
