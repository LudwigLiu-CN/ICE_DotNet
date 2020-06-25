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
    public class ReviewsMapper : ControllerBase
    {
        iceContext iceContext_ = new iceContext();

        public void Insert(Reviews review)
        {
            iceContext_.Reviews.Add(review);
            iceContext_.SaveChanges();
        }

        public int GetLatestInsertReviewId()
        {
            int latestId = (from r in iceContext_.Reviews select r.ReviewId).Max();
            return latestId;
        }
    }
}
