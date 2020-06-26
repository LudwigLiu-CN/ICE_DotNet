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

        public int GetWheatherCommented(int userId, int gameId)
        {
            var reviewIds = from wr in iceContext_.WriteReview
                            join hr in iceContext_.HasReview on wr.ReviewId equals hr.ReviewId
                            where wr.UserId == userId
                            where hr.GameId == gameId
                            select wr.ReviewId;
            ArrayList al = new ArrayList();
            foreach(var id in reviewIds)
            {
                al.Add(id);
            }
            return al.Count;
        }

        public ArrayList SelectAllComment(int gameId, int startWith, int endWith, int reverse)
        {
            var allComments = from review in iceContext_.Reviews
                              join wr in iceContext_.WriteReview on review.ReviewId equals wr.ReviewId
                              join hr in iceContext_.HasReview on wr.ReviewId equals hr.ReviewId
                              where hr.GameId == gameId
                              orderby review.ReviewDate
                              select new
                              {
                                  userId = wr.UserId,
                                  review = review
                              };
            ArrayList result = new ArrayList();
            ArrayList reviewList = new ArrayList();
            ArrayList userIds = new ArrayList();
            foreach(var cm in allComments)
            {
                reviewList.Add(cm.review);
                userIds.Add(cm.userId);
            }
            if(reverse == 1)
            {
                reviewList.Reverse();
                userIds.Reverse();
            }
            result.Add(reviewList);
            result.Add(userIds);
            return result;
        }

        public int CommentsCount(int gameId)
        {
            return (from hr in iceContext_.HasReview where hr.GameId == gameId select hr).Count();
        }
    }
}
