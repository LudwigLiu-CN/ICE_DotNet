using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessAPI.Contexts;
using DataAccessAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    public class HasReviewMapper : ControllerBase
    {
        private iceContext iceContext_ = new iceContext();

        [Route("/HasReviewMapper/DeleteByPrimaryKey")]
        [HttpGet]
        public void DeleteByPrimaryKey(int ReviewId, int GameId)
        {
            HasReview target = iceContext_.HasReview.Find(ReviewId, GameId);
            iceContext_.HasReview.Remove(target);
            iceContext_.SaveChanges();
        }

        public void Insert(HasReview target)
        {
            iceContext_.HasReview.Add(target);
            iceContext_.SaveChanges();
        }
    }
}
