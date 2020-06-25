﻿using DataAccess.Controllers;
using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommentService
{
    public class CommentServiceUtil
    {
        WriteReviewMapper writeReviewMapper = new WriteReviewMapper();
        ReviewsMapper reviewsMapper = new ReviewsMapper();
        HasReviewMapper hasReviewMapper = new HasReviewMapper();
        OrdersMapper ordersMapper = new OrdersMapper();
        UserMapper userMapper = new UserMapper();

        public Response AddComment(int thisUserId, ReviewAdder r)
        {
            Response response = new Response();

            Reviews review = new Reviews();
            review.ReviewId = 1;
            review.Content = r.content;
            review.ReviewDate = DateTime.Now;

            try
            {
                int c = writeReviewMapper.GetWheatherCommented(thisUserId, r.gameId);
                if (c == 1)
                {
                    response.status = "403";
                    response.error = "You have already commented!";
                    return response;
                }
                else if (c > 1)
                {
                    response.status = "403";
                    response.error = "Fatal error:" + c + "comments found. Please contact the backend.";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.error = "SQL Error1";
                response.status = "403";
                return response;
            }

            try
            {
                reviewsMapper.Insert(review);
                HasReview hasReview = new HasReview();
                hasReview.GameId = r.gameId;
                hasReview.ReviewId = reviewsMapper.GetLatestInsertReviewId();
                hasReviewMapper.Insert(hasReview);

                WriteReview writeReview = new WriteReview();
                writeReview.ReviewId = reviewsMapper.GetLatestInsertReviewId();
                writeReview.UserId = thisUserId;
                writeReviewMapper.Insert(writeReview);
            }
            catch (Exception e)
            {
                response.error = "SQL Error2";
                response.status = "403";
                return response;
            }

            Orders order_record = ordersMapper.SelectByPrimaryKey(r.orderId);
            order_record.Status = 3;
            ordersMapper.UpdateByPrimaryKeySelective(order_record);

            response.error = "Comment Successful";
            response.status = "200";
            return response;
        }

        //public Response AllComment(int gameId, int from = 0, int to, int reverse = 1)
        //{
        //    Response response = new Response();

        //    try
        //    {
        //        // 这里需要 writeReviewMapper 的 selectAllComment 函数，函数未实现。
        //        ArrayList commentList = writeReviewMapper.SelectAllComment(gameId, from, to - from, reverse);
        //        if (commentList.Count == 0)
        //        {
        //            response.error = "No commenet yet";
        //            response.status = "404";
        //        }
        //        else
        //        {
        //            ArrayList resultList = new ArrayList();
        //            for (int i = 0; i < commentList.Count; i++)
        //            {
        //                int uid = commentList[i];
        //                Users u = userMapper.SelectByPrimaryKey(uid);
        //                // 涉及到自定义的entity, reviewWithUser，未实现
        //                // 涉及到文件路径，暂不实现
        //            }
        //            response.result = resultList;
        //            response.status = "200";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response.error = "SQL Error!";
        //        response.status = "403";
        //    }
        //    return response;
        //}

        public Response CheckMyComment(int thisUserId, int GameId)
        {
            Response response = new Response();

            try
            {
                int c = writeReviewMapper.GetWheatherCommented(thisUserId, GameId);
                response.status = "200";
                response.error = Convert.ToString(c);
            }
            catch(Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
                return response;
            }
            return response;
        }

        public Response CommentsNumber(int GameId)
        {
            Response response = new Response();

            try
            {
                int cCount = writeReviewMapper.CommentsCount(GameId);
                ArrayList l = new ArrayList();
                l.Add(cCount);
                response.result = l;
                response.status = "200";
            }
            catch (Exception e)
            {
                response.error = "SQL Error";
                response.status = "403";
                return response;
            }
            return response;
        }
    }
}
