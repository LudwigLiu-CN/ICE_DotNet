using DataAccess.Controllers;
using DataAccessAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OrderService
{
    class OrderServiceUtil
    {
        OrdersMapper ordersMapper = new OrdersMapper();
        UserMapper userMapper = new UserMapper();
        List<Orders> orderList_0 = new List<Orders>();
        List<Orders> orderList_1 = new List<Orders>();
        List<Orders> orderList_2 = new List<Orders>();
        List<Orders> orderList_3 = new List<Orders>();
        List<Orders> orderList_4 = new List<Orders>();

        public Response InitAllOrderList(int userId)
        {
            Response response = new Response();

            if (userMapper.SelectByPrimaryKey(userId) == null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }

            List<Orders> allOrderList = ordersMapper.SelectByUserId(userId);
            orderList_0.Clear();
            orderList_1.Clear();
            orderList_2.Clear();
            orderList_3.Clear();
            orderList_4.Clear();

            for (int i = 0; i < allOrderList.Count; i++)
            {
                if(allOrderList[i].Status == 0)
                {
                    orderList_0.Add(allOrderList[i]);
                }
                else if (allOrderList[i].Status == 1)
                {
                    orderList_1.Add(allOrderList[i]);
                }
                else if (allOrderList[i].Status == 2)
                {
                    orderList_2.Add(allOrderList[i]);
                }
                else if (allOrderList[i].Status == 3)
                {
                    orderList_3.Add(allOrderList[i]);
                }
                else if (allOrderList[i].Status == 4)
                {
                    orderList_4.Add(allOrderList[i]);
                }
            }

            response.status = "200";

            return response;
        }

        public Response GetOrderList(int userId, int status)
        {
            Response response = new Response();

            if (userMapper.SelectByPrimaryKey(userId)==null)
            {
                response.status = "403";
                response.error = "";
                return response;
            }

            List<Orders> temp = new List<Orders>();

            if (status == 0)
            {
                temp = orderList_0;
            }
            else if (status == 1)
            {
                temp = orderList_1;
            }
            else if (status == 2)
            {
                temp = orderList_2;
            }
            else if (status == 3)
            {
                temp = orderList_3;
            }
            else if (status == 4)
            {
                temp = orderList_4;
            }

            // 这里缺少一个数据格式的转换，在idea中好像涉及到service，暂不处理
            // List<Orders> result = 
            ArrayList result = new ArrayList();
            for(int i = 0; i < temp.Count; i++)
            {
                result.Add(temp[i]);
            }

            response.status = "200";
            response.result = result;

            return response;
        }

        public Response ConfirmOrder(int OrderId)
        {
            Response response = new Response();

            Orders record = ordersMapper.SelectByPrimaryKey(OrderId);
            record.Status = 2;
            ordersMapper.UpdateByPrimaryKeySelective(record);
            response.status = "200";
            return response;
        }

        public Response DeliverOrder(int OrderId)
        {
            Response response = new Response();

            Orders record = ordersMapper.SelectByPrimaryKey(OrderId);
            record.Status = 1;
            ordersMapper.UpdateByPrimaryKeySelective(record);
            response.status = "200";
            return response;
        }

        // 参数是输入的json，不是严格的Orders
        public Response CreateOrder(Orders order)
        {
            Response response = new Response();

            int userId = 100002;
            
            if(userMapper.SelectByPrimaryKey(userId) == null)
            {
                response.status = "200";
                response.error = "";
                return response;
            }

            order.OrderId = 0;
            order.Status = 0;
            order.Date = new DateTime();
            order.UserId = userId;

            try
            {
                // 这部分在idea中是insertselective
                ordersMapper.Insert(order);
            }
            catch (Exception e)
            {
                response.status = "500";
                response.error = "Insert Failed";
            }

            response.status = "200";
            response.error = "Insert Success";
            return response;
        }
    }
}
